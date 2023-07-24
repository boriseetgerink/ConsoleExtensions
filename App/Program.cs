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

string input = ConsoleExtensions.ReadLine(options =>
{
    options.Prompt = ">";
    options.DefaultInput = "Hello, World!";
    options.MaskInput = false;
});
Console.WriteLine(input);

string password = ConsoleExtensions.ReadLine(options =>
{
    options.Prompt = "Password:";
    options.MaskInput = true;
});
Console.WriteLine(password);
