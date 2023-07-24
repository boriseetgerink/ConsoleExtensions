using System;
using System.Collections.Generic;
using System.Linq;
using BorisEetgerink.ConsoleExtensions.Options;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        /// <summary>
        /// Displays the prompt and allows the user to select one of the available items.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="items">The items to choose from.</param>
        /// <returns>The index of the selected item.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no items are specified. At least one item is required.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int PickOne(string prompt, IEnumerable<string> items) => PickOne(options =>
        {
            options.Prompt = prompt;
            options.Items = items.ToArray();
        });

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available items.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="items">The items to choose from.</param>
        /// <returns>The index of the selected item.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no items are specified. At least one item is required.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int PickOne(string prompt, params string[] items) => PickOne(options =>
        {
            options.Prompt = prompt;
            options.Items = items;
        });

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available items.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="defaultChoice">The index of the item selected by default.</param>
        /// <param name="items">The items to choose from.</param>
        /// <returns>The index of the selected item.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no items are specified. At least one item is required.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If defaultChoice is less than zero or equal to or greater than the number of items.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int PickOne(string prompt, int defaultChoice, IEnumerable<string> items) => PickOne(options =>
        {
            options.Prompt = prompt;
            options.DefaultChoice = defaultChoice;
            options.Items = items.ToArray();
        });

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available items.
        /// </summary>
        /// <param name="prompt">The prompt or question to display.</param>
        /// <param name="defaultChoice">The index of the item selected by default.</param>
        /// <param name="items">The items to choose from.</param>
        /// <returns>The index of the selected item.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        /// <exception cref="ArgumentException">If no items are specified. At least one item is required.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If defaultChoice is less than zero or equal to or greater than the number of items.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int PickOne(string prompt, int defaultChoice, params string[] items) => PickOne(options =>
        {
            options.Prompt = prompt;
            options.DefaultChoice = defaultChoice;
            options.Items = items;
        });

        /// <summary>
        /// Displays the prompt and allows the user to select one of the available items.
        /// </summary>
        /// <param name="optionsAction">The method configuration.</param>
        /// <returns>The index of the selected item.</returns>
        /// <exception cref="ArgumentException">If no items are specified. At least one item is required.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If defaultChoice is less than zero or equal to or greater than the number of items.</exception>
        public static int PickOne(Action<PickOneOptions> optionsAction)
        {
            PickOneOptions options = new PickOneOptions();
            optionsAction?.Invoke(options);

            if (!options.Items.Any())
            {
                throw new ArgumentException("At least one option is required.", nameof(options));
            }

            if (options.DefaultChoice < 0 || options.DefaultChoice >= options.Items.Count)
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
                for (int i = 0; i < options.Items.Count; i++)
                {
                    bool isSelected = i == choice;
                    Console.WriteLine($"{(isSelected ? '>' : ' ')}{options.Items.ElementAt(i)}");
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
                            choice = options.Items.Count - 1;
                        }
                        else
                        {
                            choice -= 1;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        if (choice == options.Items.Count - 1)
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
