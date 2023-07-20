using System;

namespace BorisEetgerink.ConsoleExtensions.Options
{
    /// <summary>
    /// Confirm options.
    /// </summary>
    public class ConfirmOptions
    {
        private string _prompt = string.Empty;

        /// <summary>
        /// Gets or sets the prompt.
        /// </summary>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        public string Prompt
        {
            get => _prompt;
            set => _prompt = value ?? throw new ArgumentNullException(nameof(value), "Prompt may not be null.");
        }

        /// <summary>
        /// Gets or sets the default choice. Defaults to True (yes).
        /// </summary>
        public bool DefaultChoice { get; set; } = true;

        /// <summary>
        /// Gets or sets the default character to use for the 'yes' option. Defaults to 'y'.
        /// </summary>
        public char YesChar { get; set; } = 'y';

        /// <summary>
        /// Gets or sets the default character to use for the 'no' option. Defaults to 'n'.
        /// </summary>
        public char NoChar { get; set; } = 'n';
    }
}
