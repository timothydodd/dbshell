﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    public class Batch : RunnableContainer, IRunnable
    {
        void IRunnable.Run()
        {
            RunContainer();
        }
    }
}
