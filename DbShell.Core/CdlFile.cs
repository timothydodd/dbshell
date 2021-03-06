﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Interfaces;

namespace DbShell.Core
{
    /// <summary>
    /// Binary file holding table data. Can be used for temporary storage of table contents.
    /// </summary>
    public class CdlFile : ElementBase, ITabularDataSource, ITabularDataTarget, IModelProvider
    {
        /// <summary>
        /// File name (should have .cdl extension)
        /// </summary>
        [XamlProperty]
        public string Name { get; set; }

        private string GetName(IShellContext context)
        {
            return context.Replace(Name);
        }

        private void OpenRead(out TableInfo table, out BinaryReader br, IShellContext context)
        {
            string file = GetName(context);
            file = context.ResolveFile(file, ResolveFileMode.Input);
            var fr = new FileInfo(file).OpenRead();
            br = new BinaryReader(fr);
            string s = br.ReadString();
            table = JsonTool.Deserilize<TableInfo>(s, x => x.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto);
            table.AfterLoadLink();
        }

        TableInfo ITabularDataSource.GetRowFormat(IShellContext context)
        {
            TableInfo table;
            BinaryReader br = null;
            try
            {
                OpenRead(out table, out br, context);
            }
            finally
            {
                if (br != null) br.Dispose();
            }
            return table;
        }

        ICdlReader ITabularDataSource.CreateReader(IShellContext context)
        {
            TableInfo table;
            BinaryReader br;
            OpenRead(out table, out br, context);
            return new CdlFileReader(table, br);
        }

        DataFormatSettings ITabularDataSource.GetSourceFormat(IShellContext context)
        {
            return null;
        }

        bool ITabularDataTarget.IsAvailableRowFormat(IShellContext context)
        {
            return false;
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options, IShellContext context, DataFormatSettings sourceDataFormat)
        {
            string file = GetName(context);
            file = context.ResolveFile(file, ResolveFileMode.Output);
            context.Info("Writing file " + Path.GetFullPath(file));
            return new CdlFileWriter(file, rowFormat);
        }

        TableInfo ITabularDataTarget.GetRowFormat(IShellContext context)
        {
            return null;
        }

        object IModelProvider.GetModel(IShellContext context)
        {
            return this;
        }

        void IModelProvider.InitializeTemplate(IRazorTemplate template, IShellContext context)
        {
            template.TabularData = this;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return String.Format("[CdlFile {0}]", Name);
        }

        public override string ToStringCtx(IShellContext context)
        {
            return String.Format("[CdlFile {0}]", context.Replace(Name));
        }
    }
}
