// See https://aka.ms/new-console-template for more information

using BorisEetgerink.ConsoleExtensions;

string? line = ConsoleExtensions.ReadLine("What is your favorite color? >", "Green");
Console.WriteLine($"|{line}|");

bool confirm = ConsoleExtensions.Confirm("Continue?", false);
Console.WriteLine(confirm);
