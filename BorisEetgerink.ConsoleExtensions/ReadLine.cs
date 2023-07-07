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

            StringBuilder input = new StringBuilder(defaultInput);
            bool originalCursorVisible = Console.CursorVisible;

            // 1. render
            // 2. while
            // 3a. wait for key
            // 3b. re-render.

            Console.CursorVisible = originalCursorVisible;
            return input.ToString();

            /*// TODO: Work with originalCursorTop and originalCursorLeft and only reset to that position if the current
            // value is different from the original position.

            // Start up
            bool originalCursorVisible = Console.CursorVisible;
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            StringBuilder input = new StringBuilder(defaultInput);

            Console.CursorVisible = false;
            Console.Write(prompt);
            Console.Write(input);
            Console.CursorVisible = true;

            int cursorPosition = input.Length;
            int maxLength = prompt.Length + input.Length + 1;
            int maxLine = Math.DivRem(maxLength, Console.BufferWidth, out int maxColumn);
            bool hasEntered = false;
            while (!hasEntered)
            {
                Console.CursorVisible = false;

                // Render loop
                // Add one, because a character could be deleted/back-spaced.
                maxLength = prompt.Length + input.Length + 1;
                maxLine = Math.DivRem(maxLength, Console.BufferWidth, out maxColumn);
                int currentLine = Math.DivRem(prompt.Length + cursorPosition, Console.BufferWidth, out int currentColumn);

                if (Console.CursorLeft != 0 || Console.CursorTop != 0)
                {
                    ResetCursorPositionFrom(currentLine);
                }

                Console.Write(new string(' ', maxLength));
                ResetCursorPositionFrom(maxLine);
                Console.Write(prompt);
                Console.Write(input);
                ResetCursorPositionFrom(maxLine);
                SetCursorPositionTo(currentLine, currentColumn);

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

            // Clean up
            Console.CursorVisible = false;
            SetCursorPositionTo(maxLine, maxColumn);
            Console.WriteLine();
            Console.CursorVisible = originalCursorVisible;

            return input.ToString();*/
        }

        /*private static void ResetCursorPositionFrom(int currentLine)
        {
            Console.CursorLeft = 0;
            if (currentLine > 0)
            {
                int newTop = Console.CursorTop - currentLine;
                Console.CursorTop = Math.Max(0, newTop);
            }
        }

        private static void SetCursorPositionTo(int currentLine, int currentColumn)
        {
            Console.CursorLeft = currentColumn;
            if (currentLine > 0)
            {
                Console.CursorTop += currentLine;
            }
        }*/

        private static int InsertCharacter(StringBuilder input, ConsoleKeyInfo key, int cursorPosition)
        {
            input.Insert(cursorPosition, key.KeyChar);
            return cursorPosition + 1;
        }
    }
}
