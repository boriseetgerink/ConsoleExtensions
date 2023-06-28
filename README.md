# .NET Console Extensions

Various console extensions.

## Confirm

Display a confirmation prompt with a preset default. The user can select the yes or no key,
press enter to select the default or escape to select the other option.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

// The default usage.
bool confirmDefault = ConsoleExtensions.Confirm("Continue?");

// Set the no option as the default.
bool continueWithCaution = ConsoleExtensions.Confirm("Are you sure?", false);

// Built in support for different languages.
bool confirmFrench = ConsoleExtensions.Confirm("Continuer?", true, 'o', 'n');
```

### Supported keys

* `Enter`: Select the default option (defaults to yes).
* `Esc`: Select the other option (defaults to no).
* `y`: The default yes-key. Can be overridden.
* `n`: The default no-key. Can be overridden.

## ReadLine

Enable a prompt and default input as an extension to `Console.ReadLine()`.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

string? line = ConsoleExtensions.ReadLine("What is your favorite color? >", "Green");
```

### Supported keys

* `Backspace` / `Delete`: remove one character to the left or right.
* `←` / `→`: move the cursor to the left or right.
* `Ctrl + ←` / `Ctrl + →`: move the cursor one word to the left or right.
* `Home` / `End`: Move the cursor to the beginning or the end of the line.
* `Esc`: Clear the line.
* `Ctrl + Z`: Reset the line to the default input.
