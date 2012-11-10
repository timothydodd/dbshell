﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Common
{
    public interface IShellContext
    {
        DatabaseInfo GetDatabaseStructure(IConnectionProvider connection);
        void SetVariable(string name, object value);
        object Evaluate(string expression);
        void EnterScope();
        void LeaveScope();
        string Replace(string replaceString, string replacePattern = null);
        void IncludeFile(string file, IShellElement parent);
        string ResolveFile(string file, ResolveFileMode mode);
        void PushExecutingFile(string file);
        void PopExecutingFile();
        string GetExecutingFile();
    }
}
