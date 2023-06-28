using System;
using System.Text;

namespace BorisEetgerink.ConsoleExtensions
{
    /// <summary>
    /// Various console extensions.
    /// </summary>
    public static class ConsoleExtensions
    {
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
            int maxLength = prompt.Length + defaultInput.Length;
            int cursorPosition = defaultInput.Length;
            bool hasEntered = false;
            while (!hasEntered)
            {
                maxLength = Math.Max(maxLength, prompt.Length + input.Length);

                Console.CursorVisible = false;
                Console.CursorLeft = 0;
                Console.Write(prompt);
                Console.Write(input);
                for (int i = Console.CursorLeft; i < maxLength; i++)
                {
                    Console.Write(' ');
                }

                Console.CursorLeft = prompt.Length + cursorPosition;
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

            // Terminate the prompt by writing a newline.
            Console.WriteLine();

            return input.ToString();
        }

        private static int InsertCharacter(StringBuilder input, ConsoleKeyInfo key, int cursorPosition)
        {
            input.Insert(cursorPosition, key.KeyChar);
            return cursorPosition + 1;
        }
    }
}
