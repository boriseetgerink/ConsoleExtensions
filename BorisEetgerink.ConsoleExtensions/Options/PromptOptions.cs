using System;

namespace BorisEetgerink.ConsoleExtensions.Options
{
    /// <summary>
    /// Prompt options.
    /// </summary>
    public abstract class PromptOptions
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
    }
}
