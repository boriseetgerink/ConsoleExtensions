using BorisEetgerink.ConsoleExtensions;

Console.WriteLine(ConsoleExtensions.Confirm(options => options.Prompt = "Continue?"));

// string? username = ConsoleExtensions.ReadLine("Username:");
// string? password = ConsoleExtensions.ReadPassword("Password:");
// Console.WriteLine($"{username}:{password}");
