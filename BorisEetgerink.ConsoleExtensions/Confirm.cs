using System;

namespace BorisEetgerink.ConsoleExtensions
{
    /// <summary>
    /// Various console extensions.
    /// </summary>
    public static partial class ConsoleExtensions
    {
        public static bool Confirm() => Confirm("Continue?");

        public static bool Confirm(string prompt) => Confirm(prompt, true);

        public static bool Confirm(string prompt, bool defaultChoice) => Confirm(prompt, defaultChoice, 'y', 'n');

        public static bool Confirm(string prompt, bool defaultChoice, char yesChar, char noChar)
        {
            if (prompt == null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            char loweredYesChar = char.ToLowerInvariant(yesChar);
            char loweredNoChar = char.ToLowerInvariant(noChar);
            char capitalizedYesChar = defaultChoice ? char.ToUpperInvariant(yesChar) : char.ToLowerInvariant(yesChar);
            char capitalizedNoChar = !defaultChoice ? char.ToUpperInvariant(noChar) : char.ToLowerInvariant(noChar);
            Console.Write($"{prompt} [{capitalizedYesChar}/{capitalizedNoChar}]:");

            ConsoleKeyInfo key;
            char loweredKeyChar;
            do
            {
                key = Console.ReadKey(true);
                loweredKeyChar = char.ToLowerInvariant(key.KeyChar);
            } while (key.Key != ConsoleKey.Enter && loweredKeyChar != loweredYesChar && loweredKeyChar != loweredNoChar);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.Write(defaultChoice ? yesChar : noChar);
                Console.WriteLine();
                return defaultChoice;
            }

            Console.Write(key.KeyChar);
            Console.WriteLine();

            return loweredKeyChar == loweredYesChar;
        }
    }
}
