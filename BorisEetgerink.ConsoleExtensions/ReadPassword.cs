using System;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        /// <summary>
        /// Display a prompt for a password, masking the input.
        /// </summary>
        /// <returns>The password entered by the user.</returns>
        public static string ReadPassword() => ReadPassword(string.Empty);

        /// <summary>
        /// Display a prompt for a password, masking the input.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "Password:".</param>
        /// <returns>The password entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        public static string ReadPassword(string prompt) => ReadLine(options =>
        {
            options.Prompt = prompt;
            options.MaskInput = true;
        });
    }
}
