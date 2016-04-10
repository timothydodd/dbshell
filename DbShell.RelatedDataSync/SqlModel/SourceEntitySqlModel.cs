﻿using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core;
using DbShell.Driver.Common.Utility;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class SourceEntitySqlModel
    {
        public NameWithSchema TableName;

        public List<SourceColumnSqlModel> Columns = new List<SourceColumnSqlModel>();
        private DataSyncSqlModel _dataSync;
        private Source _dbsh;
        public string SqlAlias;
        public DmlfSource QuerySource;
        public bool IsExternal;
        private NameWithSchema _materializedName;
        private DmlfSelect _materializeSelect;
        private NameWithSchema _externalDataName;

        public SourceEntitySqlModel(Source dbsh, DataSyncSqlModel dataSync)
        {
            _dbsh = dbsh;
            _dataSync = dataSync;
        }

        public Source Dbsh => _dbsh;
        public NameWithSchema ExternalDataName => _externalDataName;

        public void InitializeQuerySource(ITabularDataSource dataSource, IShellContext context, string sourceTableVariable, string sourceQueryVariable)
        {
            if (!_dbsh.ForceExternalSource)
            {
                // try to create non-external source

                var tableOrView = dataSource as DbShell.Core.Utility.TableOrView;

                if (!String.IsNullOrEmpty(sourceTableVariable))
                {
                    QuerySource = new DmlfSource
                    {
                        Alias = SqlAlias,
                        TableOrView = new NameWithSchema($"###({sourceTableVariable})###"),
                    };
                    TableName = new NameWithSchema(sourceTableVariable);
                    return;
                }

                if (!String.IsNullOrEmpty(sourceQueryVariable))
                {
                    QuerySource = new DmlfSource
                    {
                        Alias = SqlAlias,
                        SubQueryString = $"###({sourceQueryVariable})###",
                    };
                    return;

                }

                if (tableOrView != null)
                {
                    bool canUseTable = true;
                    LinkedDatabaseInfo linked = null;

                    var ctxConn = new NormalizedDatabaseConnectionInfo(new DatabaseConnectionInfoHolder { ProviderString = context.GetDefaultConnection() });
                    var tableConn = tableOrView.GetNormalizedConnectionInfo(context);

                    if (ctxConn != tableConn)
                    {
                        if (ctxConn.ServerConnectionString == tableConn.ServerConnectionString)
                        {
                            linked = tableConn.GetLinkedInfo();
                        }
                        else
                        {
                            canUseTable = false;
                        }
                    }

                    if (canUseTable)
                    {
                        TableName = tableOrView.GetFullName(context);
                        QuerySource = new DmlfSource
                        {
                            Alias = SqlAlias,
                            TableOrView = TableName,
                            LinkedInfo = linked,
                        };
                        return;
                    }
                }

                var query = dataSource as DbShell.Core.Query;
                if (query != null && query.GetProviderString(context) == context.GetDefaultConnection())
                {
                    string sql = context.Replace(query.Text);
                    QuerySource = new DmlfSource
                    {
                        Alias = SqlAlias,
                        SubQueryString = sql,
                    };
                    return;
                }
            }

            IsExternal = true;
            _externalDataName = new NameWithSchema(null, $"##{SqlAlias}_{new Random().Next(10000, 100000)}");
            QuerySource = new DmlfSource
            {
                Alias = SqlAlias,
                TableOrView = _externalDataName,
            };
            _dataSync.AddExternalSource(this);
        }

        public void LoadFlatColumns()
        {
            foreach (var colItem in _dbsh.Columns)
            {
                string alias = colItem.AliasOrName;
                var col = new SourceColumnSqlModel
                {
                    Alias = alias,
                };
                Columns.Add(col);
                col.Entities.Add(this);
                col.DbshColumns.Add(colItem);
                if (!String.IsNullOrEmpty(colItem.Filter))
                {
                    col.Filters.Add(colItem.Filter);
                    col.FilterType = colItem.FilterType;
                    col.CompileFilter();
                }
            }
        }

        public void MaterializeIfNeeded()
        {
            if (IsExternal) return;
            if (!_dbsh.Materialize) return;

            _materializedName = new NameWithSchema("#" + SqlAlias.Replace(".", "_"));
            _materializeSelect = new DmlfSelect();
            _materializeSelect.SingleFrom.Source = QuerySource;
            _materializeSelect.SelectIntoTable = _materializedName;
            _materializeSelect.SelectAll = true;

            QuerySource = new DmlfSource
            {
                Alias = SqlAlias,
                TableOrView = _materializedName,
            };
        }

        public void PutMaterialize(SqlScriptCompiler cmp)
        {
            if (_materializedName == null) return;
            cmp.PutSmallTitleComment($"Materialize of entity {SqlAlias}");
            cmp.StartTimeMeasure("OP");
            cmp.GenCommandSql(_materializeSelect);
            cmp.PutLogMessage(null, LogOperationType.Materialize, $"@rows rows of {SqlAlias} materialized", "OP");
        }

        public void PutDropMaterialized(SqlScriptCompiler cmp)
        {
            if (_materializedName == null) return;
            cmp.Dumper.DropTable(new TableInfo(null) { FullName = _materializedName }, false);
            cmp.EndCommand();
        }

        public string SingleKeyColumnNameOrAlias
        {
            get
            {
                var res = _dbsh.Columns.Where(x => x.IsKey).Select(x => x.AliasOrName).ToList();
                if (res.Count == 1) return res[0];
                return null;
            }
        }

        public string SingleKeyColumnOriginalName
        {
            get
            {
                var res = _dbsh.Columns.Where(x => x.IsKey).Select(x => x.Name).ToList();
                if (res.Count == 1) return res[0];
                return null;
            }
        }

        public string GetColumnName(string alias)
        {
            int index = Columns.FindIndex(x => x.Alias == alias);
            if (index >= 0) return _dbsh.Columns[index].Name;
            return alias;
        }

        public List<SourceColumnSqlModel> KeyColumns
        {
            get
            {
                var res = new List<SourceColumnSqlModel>();
                for (int i = 0; i < _dbsh.Columns.Count; i++)
                {
                    if (!_dbsh.Columns[i].IsKey) continue;
                    res.Add(Columns[i]);
                }
                return res;
            }
        }

        public bool Match(string name)
        {
            if (name == _dbsh.Alias) return true;

            var sident = StructuredIdentifier.Parse(name);
            if (sident == null) return false;
            if (sident.Count == 1)
            {
                if (_dbsh.Alias == sident.First) return true;
                if (_dbsh.Alias == null && TableName?.Name == sident.First) return true;
            }
            if (sident.Count == 2)
            {
                if (_dbsh.Alias != null) return false;
                return TableName?.Schema == sident[0] && TableName?.Name == sident[1];
            }
            return false;
        }

        public override string ToString()
        {
            return _dbsh.Alias ?? TableName?.Name;
        }
    }
}
