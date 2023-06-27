using System;
using System.Text;

namespace BorisEetgerink.ConsoleExtensions
{
    public static class ConsoleExtensions
    {
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
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorPosition == input.Length)
                        {
                            break;
                        }

                        cursorPosition++;
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
