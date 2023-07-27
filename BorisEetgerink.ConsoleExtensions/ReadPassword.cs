using System;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        /// <summary>
        /// Display a prompt for a password, masking the input.
        /// </summary>
        /// <returns>The password entered by the user.</returns>
        [Obsolete("Please use ReadLine with MaskInput set to true.")]
        public static string ReadPassword() => ReadLine(options =>
        {
            options.MaskInput = true;
        });

        /// <summary>
        /// Display a prompt for a password, masking the input.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example "Password:".</param>
        /// <returns>The password entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        [Obsolete("Please use ReadLine with MaskInput set to true.")]
        public static string ReadPassword(string prompt) => ReadLine(options =>
        {
            options.Prompt = prompt;
            options.MaskInput = true;
        });
    }
}
