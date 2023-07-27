using System;
using BorisEetgerink.ConsoleExtensions.Options;

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
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static bool Confirm(string prompt) => Confirm(options =>
        {
            options.Prompt = prompt;
        });

        /// <summary>
        /// Display a confirmation prompt with a preset default.
        /// The user can select the yes or no key, press enter to select the default or escape to select the other option.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "Continue?".</param>
        /// <param name="defaultChoice">True if the yes option is the default, false if the no option is the default. Defaults to true.</param>
        /// <returns>True if the user confirmed the prompt, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static bool Confirm(string prompt, bool defaultChoice) => Confirm(options =>
        {
            options.Prompt = prompt;
            options.DefaultChoice = defaultChoice;
        });

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
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static bool Confirm(string prompt, bool defaultChoice, char yesChar, char noChar) => Confirm(options =>
        {
            options.Prompt = prompt;
            options.DefaultChoice = defaultChoice;
            options.YesChar = yesChar;
            options.NoChar = noChar;
        });

        /// <summary>
        /// Display a confirmation prompt with a preset default.
        /// The user can select the yes or no key, press enter to select the default or escape to select the other option.
        /// </summary>
        /// <param name="optionsAction">The method configuration.</param>
        /// <returns>True if the user confirmed the prompt, false otherwise.</returns>
        public static bool Confirm(Action<ConfirmOptions> optionsAction)
        {
            ConfirmOptions options = new ConfirmOptions();
            optionsAction?.Invoke(options);

            char loweredYesChar = char.ToLowerInvariant(options.YesChar);
            char loweredNoChar = char.ToLowerInvariant(options.NoChar);
            char capitalizedYesChar = options.DefaultChoice ? char.ToUpperInvariant(options.YesChar) : char.ToLowerInvariant(options.YesChar);
            char capitalizedNoChar = !options.DefaultChoice ? char.ToUpperInvariant(options.NoChar) : char.ToLowerInvariant(options.NoChar);
            Console.Write($"{options.Prompt} [{capitalizedYesChar}/{capitalizedNoChar}]:");

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
                    Console.Write(options.DefaultChoice ? loweredYesChar : loweredNoChar);
                    Console.WriteLine();
                    return options.DefaultChoice;
                case ConsoleKey.Escape:
                    Console.Write(!options.DefaultChoice ? loweredYesChar : loweredNoChar);
                    Console.WriteLine();
                    return !options.DefaultChoice;
            }

            Console.Write(char.ToLowerInvariant(key.KeyChar));
            Console.WriteLine();
            return loweredKeyChar == loweredYesChar;
        }
    }
}
