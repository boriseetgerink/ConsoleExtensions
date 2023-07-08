using System;
using System.Collections.Generic;
using System.Linq;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        /// <summary>
        /// Displays the prompt and allows the user to select one of the available options.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="options">The options to choose from.</param>
        /// <returns>The index of the selected option.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no options are specified. At least one option is required.</exception>
        public static int PickOne(string prompt, IEnumerable<string> options) => PickOne(prompt, 0, options.ToArray());

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available options.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="options">The options to choose from.</param>
        /// <returns>The index of the selected option.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no options are specified. At least one option is required.</exception>
        public static int PickOne(string prompt, params string[] options) => PickOne(prompt, 0, options);

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available options.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="defaultChoice">The index of the option selected by default.</param>
        /// <param name="options">The options to choose from.</param>
        /// <returns>The index of the selected option.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no options are specified. At least one option is required.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If defaultChoice is less than zero or equal to or greater than the number of options.</exception>
        public static int PickOne(string prompt, int defaultChoice, IEnumerable<string> options) => PickOne(prompt, defaultChoice, options.ToArray());

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available options.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="defaultChoice">The index of the option selected by default.</param>
        /// <param name="options">The options to choose from.</param>
        /// <returns>The index of the selected option.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no options are specified. At least one option is required.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If defaultChoice is less than zero or equal to or greater than the number of options.</exception>
        public static int PickOne(string prompt, int defaultChoice, params string[] options)
        {
            if (prompt == null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            if (!options.Any())
            {
                throw new ArgumentException("At least one option is required.", nameof(options));
            }

            if (defaultChoice < 0 || defaultChoice >= options.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(defaultChoice));
            }

            // Start up.
            bool originalCursorVisible = Console.CursorVisible;
            Console.CursorVisible = false;
            int choice = defaultChoice;
            bool hasEntered = false;

            // Render and input loop.
            while (!hasEntered)
            {
                Console.WriteLine(prompt);
                for (int i = 0; i < options.Length; i++)
                {
                    bool isSelected = i == choice;
                    Console.WriteLine($"{(isSelected ? '>' : ' ')}{options[i]}");
                }

                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        hasEntered = true;
                        break;
                    case ConsoleKey.UpArrow:
                        if (choice == 0)
                        {
                            choice = options.Length - 1;
                        }
                        else
                        {
                            choice -= 1;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (choice == options.Length - 1)
                        {
                            choice = 0;
                        }
                        else
                        {
                            choice += 1;
                        }

                        break;
                }

                if (!hasEntered)
                {
                    // Reset the cursor to the start.
                    Console.CursorLeft = 0;
                    Console.CursorTop -= options.Length + 1;
                }
            }

            // Clean up.
            Console.CursorVisible = originalCursorVisible;

            return choice;
        }
    }
}
