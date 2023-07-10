using System;

namespace BorisEetgerink.ConsoleExtensions
{
    /// <summary>
    /// Various console extensions to handle user input.
    /// </summary>
    public static partial class ConsoleExtensions
    {
        private static void SetCursorPosition(int left, int top)
        {
            if (Console.CursorLeft != left)
            {
                Console.CursorLeft = left;
            }

            if (Console.CursorTop != top)
            {
                Console.CursorTop = top;
            }
        }
    }
}
