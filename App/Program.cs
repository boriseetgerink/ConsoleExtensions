﻿// See https://aka.ms/new-console-template for more information

using BorisEetgerink.ConsoleExtensions;

// string? line = ConsoleExtensions.ReadLine("What is your favorite color? >", "Green");
// Console.WriteLine($"|{line}|");

bool confirm = ConsoleExtensions.Confirm("Are you sure?", true, 'y', 'n');
Console.WriteLine(confirm);
