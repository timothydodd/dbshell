﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.Interfaces
{
    public interface IRazorTemplate
    {
        ISqlDumper Sql { get; set; }
        ITabularDataSource TabularData { get; set; }
        string Schema { get; set; }
        string Name { get; set; }
        IShellContext Context { get; set; }
        void Reset();
    }
}
