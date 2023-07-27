namespace BorisEetgerink.ConsoleExtensions.Options
{
    /// <summary>
    /// Confirm options.
    /// </summary>
    public class ConfirmOptions : PromptOptions
    {
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
