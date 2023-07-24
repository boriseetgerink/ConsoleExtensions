using System;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        private const string InvalidNumberMessage = "Invalid number.";

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <returns>The number entered by the user.</returns>
        public static int ReadInt() => ReadInt(string.Empty, null, InvalidNumberMessage);

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "ID>".</param>
        /// <returns>The number entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        public static int ReadInt(string prompt) => ReadInt(prompt, null, InvalidNumberMessage);

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "ID>".</param>
        /// <param name="invalidNumberMessage">The message to display if no valid number is entered.</param>
        /// <returns>The number entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If either prompt or invalidNumberMessage are null.</exception>
        public static int ReadInt(string prompt, string invalidNumberMessage) => ReadInt(prompt, null, invalidNumberMessage);

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "ID>".</param>
        /// <param name="defaultInput">The default number to display.</param>
        /// <returns>The number entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        public static int ReadInt(string prompt, int defaultInput) => ReadInt(prompt, (int?)defaultInput, InvalidNumberMessage);

        /// <summary>
        /// Display a prompt to enter a number.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "ID>".</param>
        /// <param name="defaultInput">The default number to display.</param>
        /// <param name="invalidNumberMessage">The message to display if no valid number is entered.</param>
        /// <returns>The number entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If either prompt or invalidNumberMessage are null.</exception>
        public static int ReadInt(string prompt, int defaultInput, string invalidNumberMessage) => ReadInt(prompt, (int?)defaultInput, invalidNumberMessage);

        private static int ReadInt(string prompt, int? defaultInput, string invalidNumberMessage)
        {
            if (prompt == null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            if (invalidNumberMessage == null)
            {
                throw new ArgumentNullException(nameof(invalidNumberMessage));
            }

            string defaultInputString = defaultInput?.ToString() ?? string.Empty;

            int input;
            while (!int.TryParse(ReadLine(options =>
                                 {
                                     options.Prompt = prompt;
                                     options.DefaultInput = defaultInputString;
                                 }),
                                 out input))
            {
                Console.WriteLine(invalidNumberMessage);
            }

            return input;
        }
    }
}
