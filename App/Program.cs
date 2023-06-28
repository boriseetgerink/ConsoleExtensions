using BorisEetgerink.ConsoleExtensions;

string? line = ConsoleExtensions.ReadLine("What is your favorite color? >", "Green");
Console.WriteLine($"|{line}|");

// The default usage.
bool confirmDefault = ConsoleExtensions.Confirm("Continue?");
Console.WriteLine(confirmDefault);

// Set the no option as the default.
bool continueWithCaution = ConsoleExtensions.Confirm("Are you sure?", false);
Console.WriteLine(continueWithCaution);

// Built in support for different languages.
bool confirmFrench = ConsoleExtensions.Confirm("Continuer?", true, 'o', 'n');
Console.WriteLine(confirmFrench);
