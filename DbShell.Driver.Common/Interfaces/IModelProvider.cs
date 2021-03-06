﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Interfaces
{
    /// <summary>
    /// Provides model for Razor template engine
    /// </summary>
    public interface IModelProvider
    {
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <returns>The model</returns>
        object GetModel(IShellContext context);

        /// <summary>
        /// initializes member of razor template
        /// </summary>
        /// <param name="template"></param>
        void InitializeTemplate(IRazorTemplate template, IShellContext context);
    }
}
