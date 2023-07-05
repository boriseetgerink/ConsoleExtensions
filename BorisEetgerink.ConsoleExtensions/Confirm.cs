using System;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        /// <summary>
        /// Display a confirmation prompt with a preset default.
        /// The user can select the yes or no key, press enter to select the default or escape to select the other option.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "Continue?".</param>
        /// <returns>True if the user confirmed the prompt, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        public static bool Confirm(string prompt) => Confirm(prompt, true);

        /// <summary>
        /// Display a confirmation prompt with a preset default.
        /// The user can select the yes or no key, press enter to select the default or escape to select the other option.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "Continue?".</param>
        /// <param name="defaultChoice">True if the yes option is the default, false if the no option is the default. Defaults to true.</param>
        /// <returns>True if the user confirmed the prompt, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>6
        public static bool Confirm(string prompt, bool defaultChoice) => Confirm(prompt, defaultChoice, 'y', 'n');

        /// <summary>
        /// Display a confirmation prompt with a preset default.
        /// The user can select the yes or no key, press enter to select the default or escape to select the other option.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "Continue?".</param>
        /// <param name="defaultChoice">True if the yes option is the default, false if the no option is the default. Defaults to true.</param>
        /// <param name="yesChar">The character to display for the yes option. Defaults to 'y'.</param>
        /// <param name="noChar">The character to display for the no option. Defaults to 'n'</param>
        /// <returns>True if the user confirmed the prompt, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
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
            } while (key.Key != ConsoleKey.Enter &&
                     key.Key != ConsoleKey.Escape &&
                     loweredKeyChar != loweredYesChar &&
                     loweredKeyChar != loweredNoChar);

            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.Write(defaultChoice ? yesChar : noChar);
                    Console.WriteLine();
                    return defaultChoice;
                case ConsoleKey.Escape:
                    Console.Write(!defaultChoice ? yesChar : noChar);
                    Console.WriteLine();
                    return !defaultChoice;
            }

            Console.Write(key.KeyChar);
            Console.WriteLine();
            return loweredKeyChar == loweredYesChar;
        }
    }
}
