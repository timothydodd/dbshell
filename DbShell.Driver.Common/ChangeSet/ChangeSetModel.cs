﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.ChangeSet
{
    [DataContract]
    public class ChangeSetModel
    {
        [XmlCollection(typeof(NameWithSchema))]
        [DataMember]
        public List<NameWithSchema> DeleteSkipList { get; set; }

        [XmlCollection(typeof (ChangeSetInsertItem))]
        [DataMember]
        public List<ChangeSetInsertItem> Inserts { get; set; }

        [XmlCollection(typeof (ChangeSetUpdateItem))]
        [DataMember]
        public List<ChangeSetUpdateItem> Updates { get; set; }

        [XmlCollection(typeof (ChangeSetDeleteItem))]
        [DataMember]
        public List<ChangeSetDeleteItem> Deletes { get; set; }

        [XmlElem]
        [DataMember]
        public bool DeleteReferencesCascade { get; set; }

        [XmlElem]
        [DataMember]
        public bool UpdateReferences { get; set; }

        [XmlElem]
        [DataMember]
        public bool DisableReferencedForeignKeys { get; set; }

        public ChangeSetModel()
        {
            Inserts = new List<ChangeSetInsertItem>();
            Updates = new List<ChangeSetUpdateItem>();
            Deletes = new List<ChangeSetDeleteItem>();
            DeleteSkipList = new List<NameWithSchema>();
        }

        //public void SaveToXml(XmlElement xml)
        //{
        //    foreach (var elem in Inserts)
        //    {
        //        elem.SaveToXml(xml.AddChild("Insert"));
        //    }
        //    foreach (var elem in Updates)
        //    {
        //        elem.SaveToXml(xml.AddChild("Update"));
        //    }
        //    foreach (var elem in Deletes)
        //    {
        //        elem.SaveToXml(xml.AddChild("Delete"));
        //    }
        //}

        //private void DumpTarget(ISqlDumper dmp, ChangeSetItem item)
        //{
        //    string linkedInfoStr = item.LinkedInfo != null ? item.LinkedInfo.ToString() : "";
        //    dmp.Put("%s%f", linkedInfoStr, item.TargetTable);
        //}

        //private void DumpWhere(ISqlDumper dmp, ChangeSetItem item, List<ChangeSetCondition> conditions, DatabaseInfo db)
        //{
        //    dmp.Put("^ where ");
        //    bool wasCond = false;
        //    foreach(var cond in conditions)
        //    {
        //        if (wasCond) dmp.Put(" ^and ");
        //        wasCond = true;
        //        DumpCondition(dmp, item, cond, db);
        //    }
        //}

        public DmlfBatch GetCommands(DatabaseInfo db, IDatabaseFactory factory)
        {
            var disableFks = new HashSet<Tuple<NameWithSchema, string>>();
            var dda = factory.CreateDataAdapter();
            var converter = new CdlValueConvertor(new DataFormatSettings());

            foreach (var upd in Updates)
            {
                if (upd.DisableReferencedForeignKeys || upd.UpdateReferences || DisableReferencedForeignKeys || UpdateReferences)
                {
                    var table = db.FindTable(upd.TargetTable);
                    if (table == null) continue;
                    foreach (var fk in table.GetReferences())
                    {
                        disableFks.Add(Tuple.Create(fk.OwnerTable.FullName, fk.ConstraintName));
                    }
                }
            }

            var res = new DmlfBatch();

            foreach (var fk in disableFks) res.DisableConstraint(fk.Item1, fk.Item2, true);

            foreach (var ins in Inserts)
            {
                ins.GetCommands(res, db, dda, converter);
            }

            foreach (var upd in Updates)
            {
                upd.GetInsertCommands(res, db, this, dda, converter);
            }

            foreach (var upd in Updates)
            {
                upd.GetCommands(res, db, this, dda, converter);
            }

            foreach (var upd in Updates)
            {
                upd.GetDeleteCommands(res, db, this);
            }

            foreach (var del in Deletes)
            {
                del.GetCommands(res, db, this);
            }

            foreach (var fk in disableFks) res.DisableConstraint(fk.Item1, fk.Item2, false);

            res.Commands.ForEach(x =>
                {
                    var cmd = x as DmlfCommandBase;
                    if (cmd != null) cmd.SimplifyFromAliases();
                });

            return res;
        }

        public void DumpSql(ISqlDumper dmp, DatabaseInfo db)
        {
            var commands = GetCommands(db, dmp.Factory);
            commands.GenSql(dmp);
        }

        //public void LoadFromXml(XmlElement xml)
        //{
        //    Inserts.Clear();
        //    Updates.Clear();
        //    Deletes.Clear();

        //    foreach(XmlElement xitem in xml.SelectNodes("Insert"))
        //    {
        //        var item = new ChangeSetInsertItem();
        //        item.LoadFromXml(xitem);
        //        Inserts.Add(item);
        //    }
        //}
        public bool HasChanges()
        {
            return Updates.Any() || Inserts.Any() || Deletes.Any();
        }

        public static ChangeSetModel LoadFromFile(string fileName)
        {
            var doc = new XmlDocument();
            doc.LoadXml(File.ReadAllText(fileName));
            var res = new ChangeSetModel();
            res.LoadProperties(doc.DocumentElement);
            return res;
        }
    }
}