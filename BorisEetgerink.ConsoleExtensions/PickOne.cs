using System;
using System.Collections.Generic;
using System.Linq;
using BorisEetgerink.ConsoleExtensions.Options;

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
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int PickOne(string prompt, IEnumerable<string> options) =>
            PickOne(opts =>
            {
                opts.Prompt = prompt;
                opts.Options = options.ToArray();
            });

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available options.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="options">The options to choose from.</param>
        /// <returns>The index of the selected option.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no options are specified. At least one option is required.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int PickOne(string prompt, params string[] options) =>
            PickOne(opts =>
            {
                opts.Prompt = prompt;
                opts.Options = options;
            });

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
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int PickOne(string prompt, int defaultChoice, IEnumerable<string> options) =>
            PickOne(opts =>
            {
                opts.Prompt = prompt;
                opts.DefaultChoice = defaultChoice;
                opts.Options = options.ToArray();
            });

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
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int PickOne(string prompt, int defaultChoice, params string[] options) =>
            PickOne(opts =>
            {
                opts.Prompt = prompt;
                opts.DefaultChoice = defaultChoice;
                opts.Options = options;
            });

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available options.
        /// </summary>
        /// <param name="optionsAction">The method configuration.</param>
        /// <returns>The index of the selected option.</returns>
        /// <exception cref="ArgumentException">If no options are specified. At least one option is required.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If defaultChoice is less than zero or equal to or greater than the number of options.</exception>
        public static int PickOne(Action<PickOneOptions> optionsAction)
        {
            if (optionsAction == null)
            {
                throw new ArgumentNullException(nameof(optionsAction));
            }

            PickOneOptions options = new PickOneOptions();
            optionsAction(options);

            if (!options.Options.Any())
            {
                throw new ArgumentException("At least one option is required.", nameof(options));
            }

            if (options.DefaultChoice < 0 || options.DefaultChoice >= options.Options.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(options.DefaultChoice));
            }

            // Start up.
            bool originalCursorVisible = Console.CursorVisible;
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            Console.CursorVisible = false;
            int choice = options.DefaultChoice;
            bool hasEntered = false;

            // Render and input loop.
            while (!hasEntered)
            {
                SetCursorPosition(originalCursorLeft, originalCursorTop);
                Console.WriteLine(options.Prompt);
                for (int i = 0; i < options.Options.Count; i++)
                {
                    bool isSelected = i == choice;
                    Console.WriteLine($"{(isSelected ? '>' : ' ')}{options.Options.ElementAt(i)}");
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
                            choice = options.Options.Count - 1;
                        }
                        else
                        {
                            choice -= 1;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (choice == options.Options.Count - 1)
                        {
                            choice = 0;
                        }
                        else
                        {
                            choice += 1;
                        }

                        break;
                }
            }

            // Clean up.
            Console.CursorVisible = originalCursorVisible;

            return choice;
        }
    }
}
