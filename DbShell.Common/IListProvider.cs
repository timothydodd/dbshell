﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Common
{
    public interface IListProvider
    {
        IEnumerable GetList();
    }
}