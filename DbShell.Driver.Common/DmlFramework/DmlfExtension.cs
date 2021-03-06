﻿using System;
using System.Collections.Generic;
using System.IO;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public static class DmlfExtension
    {
        public static bool IsValid(this DmlfColumnRef col)
        {
            return col != null && col.ColumnName != null;
        }

        public static void GenSql(this DmlfJoinType join, ISqlDumper dmp)
        {
            switch (join)
            {
                case DmlfJoinType.Inner:
                    dmp.Put("^inner ^join");
                    break;
                case DmlfJoinType.Left:
                    dmp.Put("^left ^join");
                    break;
                case DmlfJoinType.Right:
                    dmp.Put("^right ^join");
                    break;
                case DmlfJoinType.Outer:
                    dmp.Put("^full ^outer ^join");
                    break;
                case DmlfJoinType.CrossApply:
                    dmp.Put("^cross ^apply");
                    break;
                case DmlfJoinType.OuterApply:
                    dmp.Put("^outer ^apply");
                    break;
            }
        }

        public static void GenSql(this DmlfSortOrderType type, ISqlDumper dmp)
        {
            switch (type)
            {
                case DmlfSortOrderType.Ascending:
                    dmp.Put("^asc");
                    break;
                case DmlfSortOrderType.Descending:
                    dmp.Put("^desc");
                    break;
            }
        }

        public static DmlfSortOrderType GetOpposite(this DmlfSortOrderType type)
        {
            if (type == DmlfSortOrderType.Ascending) return DmlfSortOrderType.Descending;
            else return DmlfSortOrderType.Ascending;
        }

        //public static DmlfColumnRef FindColumn(this IEnumerable<DmlfSource> tables, string name, IDmlfHandler handler)
        //{
        //    name = (name ?? "").Trim();
        //    foreach (var tbl in tables)
        //    {
        //        var ts = handler.GetStructure(tbl == null ? null : tbl.TableOrView);
        //        foreach (var col in ts.Columns)
        //        {
        //            if (tbl != null)
        //            {
        //                string fullname = tbl.AliasOrName + "." + col.Name;
        //                if (String.Compare(fullname, name, true) == 0) return new DmlfColumnRef
        //                {
        //                    Source = tbl,
        //                    ColumnName = col.Name
        //                };
        //            }
        //            if (String.Compare(col.Name, name, true) == 0) return new DmlfColumnRef
        //            {
        //                Source = tbl,
        //                ColumnName = col.Name
        //            };
        //        }
        //    }
        //    return null;
        //}

        public static DmlfSource FindAnySource(this IEnumerable<DmlfEqualCondition> conditions, bool left, bool right)
        {
            foreach (var cond in conditions)
            {
                if (left)
                {
                    var ce = cond.LeftExpr as DmlfColumnRefExpression;
                    if (ce != null) return ce.Column.Source;
                }
                if (right)
                {
                    var ce = cond.RightExpr as DmlfColumnRefExpression;
                    if (ce != null) return ce.Column.Source;
                }
            }
            return null;
        }

        public static string ToSql(this IDmlfNode node, IDatabaseFactory factory)
        {
            if (factory == null) return "";
            var sw = new StringWriter();
            var dmp = factory.CreateDumper(new SqlOutputStream(factory.CreateDialect(), sw, SqlFormatProperties.Default), SqlFormatProperties.Default);
            node.GenSql(dmp);
            return sw.ToString();
        }

        public static string[] GetNames(this IEnumerable<DmlfColumnRef> cols)
        {
            var res = new List<string>();
            foreach (var col in cols) res.Add(col.ColumnName);
            return res.ToArray();
        }
    }
}
