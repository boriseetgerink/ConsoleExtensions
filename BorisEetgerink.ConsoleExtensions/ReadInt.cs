using System;
using BorisEetgerink.ConsoleExtensions.Options;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <returns>The number entered by the user.</returns>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int ReadInt() => ReadInt(_ => {});

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "ID>".</param>
        /// <returns>The number entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int ReadInt(string prompt) => ReadInt(options =>
        {
            options.Prompt = prompt;
        });

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "ID>".</param>
        /// <param name="invalidNumberMessage">The message to display if no valid number is entered.</param>
        /// <returns>The number entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If either prompt or invalidNumberMessage are null.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int ReadInt(string prompt, string invalidNumberMessage) => ReadInt(options =>
        {
            options.Prompt = prompt;
            options.InvalidNumberMessage = invalidNumberMessage;
        });

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "ID>".</param>
        /// <param name="defaultInput">The default number to display.</param>
        /// <returns>The number entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int ReadInt(string prompt, int defaultInput) => ReadInt(options =>
        {
            options.Prompt = prompt;
            options.DefaultInput = defaultInput;
        });

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "ID>".</param>
        /// <param name="defaultInput">The default number to display.</param>
        /// <param name="invalidNumberMessage">The message to display if no valid number is entered.</param>
        /// <returns>The number entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If either prompt or invalidNumberMessage are null.</exception>
        [Obsolete("Please use the overload with the optionsAction parameter.")]
        public static int ReadInt(string prompt, int defaultInput, string invalidNumberMessage) => ReadInt(options =>
        {
            options.Prompt = prompt;
            options.DefaultInput = defaultInput;
            options.InvalidNumberMessage = invalidNumberMessage;
        });

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="optionsAction">The method configuration.</param>
        /// <returns>The number entered by the user.</returns>
        public static int ReadInt(Action<ReadIntOptions> optionsAction)
        {
            ReadIntOptions options = new ReadIntOptions();
            optionsAction?.Invoke(options);

            string defaultInputString = options.DefaultInput?.ToString() ?? string.Empty;

            int input;
            while (!int.TryParse(ReadLine(opts =>
                                 {
                                     opts.Prompt = options.Prompt;
                                     opts.DefaultInput = defaultInputString;
                                     opts.MaskInput = options.MaskInput;
                                 }),
                                 out input))
            {
                Console.WriteLine(options.InvalidNumberMessage);
            }

            return input;
        }
    }
}
