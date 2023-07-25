using System;

namespace BorisEetgerink.ConsoleExtensions.Options
{
    /// <summary>
    /// ReadInt options.
    /// </summary>
    public class ReadIntOptions : PromptOptions
    {
        private string _invalidNumberMessage = "Invalid number.";

        /// <summary>
        /// Gets or sets the default input.
        /// </summary>
        public int? DefaultInput { get; set; }

        /// <summary>
        /// Gets or sets the message to display if no valid number is entered.
        /// </summary>
        /// <exception cref="ArgumentNullException">If the value is null.</exception>
        public string InvalidNumberMessage
        {
            get => _invalidNumberMessage;
            set => _invalidNumberMessage = value ?? throw new ArgumentNullException(nameof(value), "Invalid number message may not be null.");
        }

        /// <summary>
        /// Gets or sets whether to display asterisks instead of the plain text input.
        /// </summary>
        public bool MaskInput { get; set; }
    }
}
