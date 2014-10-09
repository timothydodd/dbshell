﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Excel.ExcelModels;

namespace DbShell.Excel
{
    public class Create : ExcelRunnableBase
    {
        /// <summary>
        /// file name of Excel file
        /// </summary>
        [XamlProperty]
        public string File { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Output);
            context.OutputMessage("Writing file " + Path.GetFullPath(file));
            context.SetVariable(GetExcelVariableName(context), ExcelModel.CreateFile(file));
        }
    }
}
