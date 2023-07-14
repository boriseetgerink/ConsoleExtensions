using BorisEetgerink.ConsoleExtensions;

string? username = ConsoleExtensions.ReadLine("Username:");
string? password = ConsoleExtensions.ReadPassword("Password:");
Console.WriteLine($"{username}:{password}");
