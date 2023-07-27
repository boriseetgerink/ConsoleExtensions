# .NET Console Extensions

Various console extensions to handle user input. Bug reports, feature ideas and PRs are welcome through the GitHub project. 

## Confirm

Display a confirmation prompt with a preset default.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

bool confirmed = ConsoleExtensions.Confirm(options =>
{
    options.Prompt = "Continue?";
    options.DefaultChoice = true;
    options.YesChar = 'y';
    options.NoChar = 'n';
});
```

### Output

```
Continue? [Y/n]:
```

## PickOne

Display a prompt with a list of options.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

int selectedIndex = ConsoleExtensions.PickOne(options =>
{
    options.Prompt = "Which is your favorite OS?";
    options.Items = new[] { "Linux", "MacOS", "Windows" };
    options.DefaultChoice = 2;
});
```

### Output

```
Pick your favorite OS:
 Linux
 MacOS
>Windows
```

## ReadInt

Extension to ReadLine to enter a number.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

int number = ConsoleExtensions.ReadInt(options =>
{
    options.Prompt = "ID:";
    options.DefaultInput = 42;
    options.InvalidNumberMessage = "Invalid number...";
});
```

### Output

```
ID:abc
Invalid number...
ID:42
```

## ReadLine

Enable a prompt and default input as an extension to `Console.ReadLine()`.
Optionally mask input with asterisks for password entry, for example.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

string username = ConsoleExtensions.ReadLine(options =>
{
    options.Prompt = "Username:";
    options.DefaultInput = "Boris";
    options.MaskInput = false;
});

string password = ConsoleExtensions.ReadLine(options =>
{
    options.Prompt = "Password:";
    options.MaskInput = true;
});
```

### Output

```
Username:Boris
Password:************
```

## Supported keys

### Confirm

* `Enter`: Select the default option (defaults to yes).
* `Esc`: Select the other option (defaults to no).
* `y`: The default yes-key. Can be overridden.
* `n`: The default no-key. Can be overridden.

### PickOne

* `↑` / `↓`: Select the previous or the next option from the list.
* `Enter`: Confirm the selected option.

### ReadLine, ReadPassword, ReadInt

* `Backspace` / `Delete`: Remove one character to the left or right.
* `←` / `→`: Move the cursor to the left or right.
* `Ctrl + ←` / `Ctrl + →`: Move the cursor one word to the left or right.
* `Home` / `End`: Move the cursor to the beginning or the end of the line.
* `Esc`: Clear the line.
* `Ctrl + Z`: Reset the line to the default input.
* `Enter`: Confirm the input.
