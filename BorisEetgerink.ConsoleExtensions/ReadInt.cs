using System;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        private const string InvalidNumberMessage = "Invalid number.";

        public static int ReadInt() => ReadInt(string.Empty, null, InvalidNumberMessage);

        public static int ReadInt(string prompt) => ReadInt(prompt, null, InvalidNumberMessage);

        public static int ReadInt(string prompt, string invalidNumberMessage) => ReadInt(prompt, null, invalidNumberMessage);

        public static int ReadInt(string prompt, int defaultInput) => ReadInt(prompt, (int?)defaultInput, InvalidNumberMessage);

        public static int ReadInt(string prompt, int defaultInput, string invalidNumberMessage) => ReadInt(prompt, (int?)defaultInput, invalidNumberMessage);

        private static int ReadInt(string prompt, int? defaultInput, string invalidNumberMessage)
        {
            if (prompt == null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            string defaultInputString = defaultInput?.ToString() ?? string.Empty;

            return defaultInput ?? 0;
        }
    }
}
