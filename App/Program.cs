using BorisEetgerink.ConsoleExtensions;

bool confirmed = ConsoleExtensions.Confirm(options =>
{
    options.Prompt = "Continue?";
    options.DefaultChoice = true;
    options.YesChar = 'y';
    options.NoChar = 'n';
});
Console.WriteLine(confirmed);

int selectedIndex = ConsoleExtensions.PickOne(options =>
{
    options.Prompt = "Which is your favorite OS?";
    options.Items = new[] { "Linux", "MacOS", "Windows" };
    options.DefaultChoice = 2;
});
Console.WriteLine(selectedIndex);

// string? username = ConsoleExtensions.ReadLine("Username:");
// string? password = ConsoleExtensions.ReadPassword("Password:");
// Console.WriteLine($"{username}:{password}");
