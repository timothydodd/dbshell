﻿using System.Collections.Generic;
using System.Xml;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class TableInfo : ColumnListInfo
    {
        public TableInfo(DatabaseInfo database)
            : base(database)
        {
        }

        private List<ForeignKeyInfo> _foreignKeys = new List<ForeignKeyInfo>();

        [XmlSubElem]
        public PrimaryKeyInfo PrimaryKey { get; set; }

        [XmlCollection(typeof(ForeignKeyInfo))]
        public List<ForeignKeyInfo> ForeignKeys { get { return _foreignKeys; } }

        public TableInfo Clone()
        {
            var res = new TableInfo(OwnerDatabase);
            res.Assign(this);
            return res;
        }

        public ColumnInfo FindAutoIncrementColumn()
        {
            foreach (var col in Columns)
            {
                if (col.AutoIncrement) return col;
            }
            return null;
        }

        public List<ForeignKeyInfo> GetReferences()
        {
            var res = new List<ForeignKeyInfo>();
            foreach (var table in OwnerDatabase.Tables)
            {
                foreach (var fk in table.ForeignKeys)
                {
                    if (fk.RefTable == this) res.Add(fk);
                }
            }
            return res;
        }

        public void SaveToXml(XmlElement xml)
        {
            this.SaveProperties(xml);
        }

        public void LoadFromXml(XmlElement xml)
        {
            this.LoadProperties(xml);
        }
    }
}
