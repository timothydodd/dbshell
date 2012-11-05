﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// CSV data file
    /// </summary>
    public class CsvFile : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        /// <summary>
        /// File name (should have .csv extension)
        /// </summary>
        public string Name { get; set; }

        private char _delimiter = ',';

        public char Delimiter
        {
            get { return _delimiter; }
            set { _delimiter = value; }
        }

        private char _quote = '"';

        public char Quote
        {
            get { return _quote; }
            set { _quote = value; }
        }

        private string _endOfLine = "\r\n";

        public string EndOfLine
        {
            get { return _endOfLine; }
            set { _endOfLine = value; }
        }

        private char _escape = '"';

        public char Escape
        {
            get { return _escape; }
            set { _escape = value; }
        }

        private char _comment = '#';

        public char Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        private bool _hasHeaders = true;

        public bool HasHeaders
        {
            get { return _hasHeaders; }
            set { _hasHeaders = value; }
        }

        private CsvQuotingMode _quotingMode = CsvQuotingMode.OnlyIfNecessary;

        public CsvQuotingMode QuotingMode
        {
            get { return _quotingMode; }
            set { _quotingMode = value; }
        }

        protected Encoding _encoding = System.Text.Encoding.UTF8;

        public Encoding Encoding
        {
            get { return _encoding; }
            set { _encoding = value; }
        }

        private bool _trimSpaces = false;

        public bool TrimSpaces
        {
            get { return _trimSpaces; }
            set { _trimSpaces = value; }
        }

        private string GetName()
        {
            return Context.Replace(Name);
        }

        private LumenWorks.Framework.IO.Csv.CsvReader CreateCsvReader()
        {
            string name = GetName();
            var textReader = new StreamReader(name, Encoding);
            var reader = new LumenWorks.Framework.IO.Csv.CsvReader(textReader, HasHeaders, Delimiter, Quote, Escape, Comment,
                                                                   TrimSpaces ? LumenWorks.Framework.IO.Csv.ValueTrimmingOptions.UnquotedOnly : LumenWorks.Framework.IO.Csv.ValueTrimmingOptions.None);
            return reader;
        }

        TableInfo ITabularDataSource.GetRowFormat()
        {
            using (var reader = CreateCsvReader())
            {
                return GetStructure(reader);
            }
        }

        ICdlReader ITabularDataSource.CreateReader()
        {
            var reader = CreateCsvReader();
            return new CsvReader(GetStructure(reader), reader);
        }

        bool ITabularDataTarget.AvailableRowFormat
        {
            get { return false; }
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options)
        {
            var fs = System.IO.File.OpenWrite(GetName());
            var fw = new StreamWriter(fs, Encoding);
            var writer = new CsvWriter(fw, Delimiter, Quote, Escape, Comment, QuotingMode, EndOfLine);
            if (HasHeaders)
            {
                writer.WriteRow(rowFormat.Columns.Select(c => c.Name));
            }
            return writer;
        }

        private TableInfo GetStructure(LumenWorks.Framework.IO.Csv.CsvReader reader)
        {
            var res = new TableInfo(null);
            if (HasHeaders)
            {
                foreach (string col in reader.GetFieldHeaders())
                {
                    res.Columns.Add(new ColumnInfo(res) {CommonType = new DbTypeString(), DataType = "nvarchar", Length = -1, Name = col});
                }
            }
            else
            {
                for (int i = 1; i <= reader.FieldCount; i++)
                {
                    res.Columns.Add(new ColumnInfo(res) { CommonType = new DbTypeString(), DataType = "nvarchar", Length = -1, Name = String.Format("#{0}", i) });
                }
            }
            return res;
        }


        TableInfo ITabularDataTarget.GetRowFormat()
        {
            throw new NotImplementedException();
        }
    }
}