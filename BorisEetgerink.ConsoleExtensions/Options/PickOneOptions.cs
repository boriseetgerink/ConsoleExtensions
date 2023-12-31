﻿using System;
using System.Collections.Generic;

namespace BorisEetgerink.ConsoleExtensions.Options
{
    /// <summary>
    /// PickOne options.
    /// </summary>
    public class PickOneOptions : PromptOptions
    {
        /// <summary>
        /// Gets or sets the index of the option selected by default.
        /// </summary>
        public int DefaultChoice { get; set; }

        /// <summary>
        /// Gets or sets the items to choose from. Must contain at least one item.
        /// </summary>
        public IReadOnlyCollection<string> Items { get; set; } = Array.Empty<string>();
    }
}
