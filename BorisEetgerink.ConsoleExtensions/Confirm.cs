namespace BorisEetgerink.ConsoleExtensions
{
    /// <summary>
    /// Various console extensions.
    /// </summary>
    public static partial class ConsoleExtensions
    {
        public static bool Confirm() => Confirm("Are you sure?");

        public static bool Confirm(string prompt) => Confirm(prompt, true);

        public static bool Confirm(string prompt, bool defaultChoice) => Confirm(prompt, defaultChoice, 'y', 'n');

        public static bool Confirm(string prompt, bool defaultChoice, char yesChar, char noChar)
        {
            return defaultChoice;
        }
    }
}
