using System;
using System.Text;

namespace BorisEetgerink.ConsoleExtensions
{
    public static partial class ConsoleExtensions
    {
        /// <summary>
        /// Accept input without displaying a prompt or default input.
        /// </summary>
        /// <returns>The input entered by the user.</returns>
        public static string ReadLine() => ReadLine(string.Empty, string.Empty);

        /// <summary>
        /// Display a prompt without a default input.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example ">".</param>
        /// <returns>The input entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If prompt is null.</exception>
        public static string ReadLine(string prompt) => ReadLine(prompt, string.Empty);

        /// <summary>
        /// Display a prompt with a default input.
        /// </summary>
        /// <param name="prompt">The prompt to display, for example ">".</param>
        /// <param name="defaultInput">The default input to display, for example "Hello, World!".</param>
        /// <returns>The input entered by the user.</returns>
        /// <exception cref="ArgumentNullException">If either prompt or defaultInput are null.</exception>
        public static string ReadLine(string prompt, string defaultInput)
        {
            if (prompt == null)
            {
                throw new ArgumentNullException(nameof(prompt));
            }

            if (defaultInput == null)
            {
                throw new ArgumentNullException(nameof(defaultInput));
            }

            bool originalCursorVisible = Console.CursorVisible;
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;

            StringBuilder input = new StringBuilder(defaultInput);

            // The cursor position relative to the input. Starts at the end of the input.
            // Easier to work with, as it does not have to take line breaks and prompt length into account.
            int cursorPosition = input.Length;

            bool hasEntered = false;
            while (!hasEntered)
            {
                Console.CursorVisible = false;
                SetCursorPosition(originalCursorLeft, originalCursorTop);
                Console.Write(prompt);
                Console.Write(input);
                Console.Write(' '); // in case of delete or backspace.
                SetCursorPosition(originalCursorLeft, originalCursorTop, prompt.Length, cursorPosition);
                Console.CursorVisible = true;

                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                        if (cursorPosition == 0)
                        {
                            break;
                        }

                        cursorPosition--;
                        input.Remove(cursorPosition, 1);
                        break;
                    case ConsoleKey.Delete:
                        if (cursorPosition == input.Length)
                        {
                            break;
                        }

                        input.Remove(cursorPosition, 1);
                        break;
                    case ConsoleKey.End:
                        cursorPosition = input.Length;
                        break;
                    case ConsoleKey.Enter:
                        hasEntered = true;
                        break;
                    case ConsoleKey.Escape:
                        input.Clear();
                        cursorPosition = 0;
                        break;
                    case ConsoleKey.Home:
                        cursorPosition = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (cursorPosition == 0)
                        {
                            break;
                        }

                        cursorPosition--;

                        if (key.Modifiers.HasFlag(ConsoleModifiers.Control))
                        {
                            while (cursorPosition > 0 && input[cursorPosition] != ' ')
                            {
                                cursorPosition--;
                            }
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorPosition == input.Length)
                        {
                            break;
                        }

                        cursorPosition++;

                        if (key.Modifiers.HasFlag(ConsoleModifiers.Control))
                        {
                            while (cursorPosition < input.Length && input[cursorPosition] != ' ')
                            {
                                cursorPosition++;
                            }
                        }

                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.Z:
                        if (key.Modifiers.HasFlag(ConsoleModifiers.Control))
                        {
                            input.Clear();
                            input.Append(defaultInput);
                            cursorPosition = input.Length;
                        }
                        else
                        {
                            cursorPosition = InsertCharacter(input, key, cursorPosition);
                        }

                        break;
                    default:
                        cursorPosition = InsertCharacter(input, key, cursorPosition);
                        break;
                }
            }

            Console.WriteLine();
            Console.CursorVisible = originalCursorVisible;

            return input.ToString();
        }

        private static void SetCursorPosition(int originalCursorLeft, int originalCursorTop)
        {
            if (Console.CursorLeft != originalCursorLeft)
            {
                Console.CursorLeft = originalCursorLeft;
            }

            if (Console.CursorTop != originalCursorTop)
            {
                Console.CursorTop = originalCursorTop;
            }
        }

        private static void SetCursorPosition(int originalCursorLeft, int originalCursorTop, int promptLength, int relativeCursorPosition)
        {
            int cursorOffset = originalCursorTop * Console.BufferWidth + originalCursorLeft + promptLength + relativeCursorPosition;
            int top = Math.DivRem(cursorOffset, Console.BufferWidth, out int left);
            SetCursorPosition(left, top);
        }

        private static int InsertCharacter(StringBuilder input, ConsoleKeyInfo key, int cursorPosition)
        {
            input.Insert(cursorPosition, key.KeyChar);
            return cursorPosition + 1;
        }
    }
}
