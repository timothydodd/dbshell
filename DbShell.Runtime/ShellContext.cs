﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using log4net;


namespace DbShell.Runtime
{
    public class ShellContext : IShellContext, IDisposable
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly Dictionary<IConnectionProvider, DatabaseInfo> _dbCache = new Dictionary<IConnectionProvider, DatabaseInfo>();
        private readonly ScriptEngine _engine;
        private readonly List<ScriptScope> _scopeStack = new List<ScriptScope>();
        private readonly List<string> _executingFileStack = new List<string>();

        public ShellContext()
        {
            _engine = Python.CreateEngine();
            _scopeStack.Add(_engine.CreateScope());
        }

        public DatabaseInfo GetDatabaseStructure(IConnectionProvider connection)
        {
            if (!_dbCache.ContainsKey(connection))
            {
                _log.InfoFormat("Downloading structure for connection {0}", connection);
                var analyser = connection.Factory.CreateAnalyser();
                using (var conn = connection.Connect())
                {
                    analyser.Run(conn, conn.Database);
                    _dbCache[connection] = analyser.Result;
                }
            }
            return _dbCache[connection];
        }

        private ScriptScope Scope
        {
            get { return _scopeStack.Last(); }
        }

        public void Dispose()
        {
        }

        public object Evaluate(string expression)
        {
            return _engine.Execute(expression, Scope);
        }


        public void SetVariable(string name, object value)
        {
            Scope.SetVariable(name, value);
        }

        public void EnterScope()
        {
            _scopeStack.Add(_engine.CreateScope(Scope));
        }

        public void LeaveScope()
        {
            _scopeStack.RemoveAt(_scopeStack.Count - 1);
        }

        private string ReplaceMatch(Match m)
        {
            return Evaluate(m.Groups[1].Value).SafeToString();
        }

        public string Replace(string replaceString, string replacePattern = null)
        {
            if (replaceString == null) return null;
            return Regex.Replace(replaceString, replacePattern ?? @"\$\{([^\}]+)\}", ReplaceMatch);
        }

        public void IncludeFile(string file, IShellElement parent)
        {
            using (var fr = new FileInfo(file).OpenRead())
            {
                object obj = XamlReader.Load(fr);
                var runnable = obj as IRunnable;
                if (runnable == null) throw new Exception(String.Format("DBSH-00059 Included file {0} doesn't contain root element implementing IRunnable", file));
                var shellElem = obj as IShellElement;
                if (shellElem != null) ShellRunner.ProcessLoadedElement(shellElem, parent, this);
                try
                {
                    PushExecutingFile(file);
                    runnable.Run();
                }
                finally
                {
                    PopExecutingFile();
                }
            }
        }

        private string SearchExistingFile(string file, params string[] folders)
        {
            foreach (string folder in folders)
            {
                if (folder == null) continue;
                string fn = Path.Combine(folder, file);
                if (System.IO.File.Exists(fn)) return fn;
            }
            if (System.IO.File.Exists(file)) return file;
            throw new Exception(String.Format("DBSH-00063 Could not find file {0}, searched in folders {1}", file, folders.CreateDelimitedText(";")));
        }

        public string ResolveFile(string file, ResolveFileMode mode)
        {
            switch (mode)
            {
                case ResolveFileMode.DbShell:
                    return SearchExistingFile(file, GetExecutingFolder());
                case ResolveFileMode.Template:
                    return SearchExistingFile(file, GetTemplatesFolder(), GetExecutingFolder());
                case ResolveFileMode.Input:
                    return SearchExistingFile(file, GetExecutingFolder());
            }
            return file;
        }

        private string GetTemplatesFolder()
        {
            return Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "templates");
        }

        private string GetExecutingFolder()
        {
            string file = GetExecutingFile();
            if (file != null) return Path.GetDirectoryName(file);
            return null;
        }

        public void PushExecutingFile(string file)
        {
            _executingFileStack.Add(file);
        }

        public void PopExecutingFile()
        {
            _executingFileStack.RemoveAt(_executingFileStack.Count - 1);
        }

        public string GetExecutingFile()
        {
            if (_executingFileStack.Count > 0) return _executingFileStack[_executingFileStack.Count - 1];
            return null;
        }
    }
}
