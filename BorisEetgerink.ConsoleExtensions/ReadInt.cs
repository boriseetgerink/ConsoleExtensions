using System;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        public static int ReadInt() => ReadInt(string.Empty, null);

        public static int ReadInt(string prompt) => ReadInt(prompt, null);

        public static int ReadInt(string prompt, int defaultInput) => ReadInt(prompt, (int?)defaultInput);

        private static int ReadInt(string prompt, int? defaultInput)
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
