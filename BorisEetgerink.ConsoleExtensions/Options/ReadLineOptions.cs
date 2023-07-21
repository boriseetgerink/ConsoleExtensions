using System;

namespace BorisEetgerink.ConsoleExtensions.Options
{
    /// <summary>
    /// ReadLine options.
    /// </summary>
    public class ReadLineOptions : PromptOptions
    {
        private string _defaultInput = string.Empty;

        /// <summary>
        /// Gets or sets the default input.
        /// </summary>
        /// <exception cref="ArgumentNullException">If default input is null.</exception>
        public string DefaultInput
        {
            get => _defaultInput;
            set => _defaultInput = value ?? throw new ArgumentNullException(nameof(value), "Default input may not be null.");
        }

        /// <summary>
        /// Gets or sets whether to display asterisks instead of the plain text input.
        /// </summary>
        public bool MaskInput { get; set; }
    }
}
