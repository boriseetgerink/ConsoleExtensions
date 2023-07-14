# .NET Console Extensions

Various console extensions to handle user input. Bug reports, feature ideas and PRs are welcome through the GitHub project. 

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

### Output

```
Continue? [Y/n]:
```

### Supported keys

* `Enter`: Select the default option (defaults to yes).
* `Esc`: Select the other option (defaults to no).
* `y`: The default yes-key. Can be overridden.
* `n`: The default no-key. Can be overridden.

## PickOne

Display a prompt with a list of options. The user can select the appropriate option with the up and down arrow keys and
confirm with the enter key.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

// Select from a list of hard-coded options:
int selectedIndex = ConsoleExtensions.PickOne("Which is your favorite OS?", "Linux", "MacOS", "Windows");

// Select from an IEnumerable<string> of options:
List<string> operatingSystems = new() { "Linux", "MacOS", "Windows" };
int selectedIndex = ConsoleExtensions.PickOne("Pick your favorite OS:", operatingSystems);

// Optionally set the selected index (defaults to zero, the first option):
List<string> operatingSystems = new() { "Linux", "MacOS", "Windows" };
int selectedIndex = ConsoleExtensions.PickOne("Pick your favorite OS:", 2, operatingSystems);
```

### Output

```
Pick your favorite OS:
>Linux
 MacOS
 Windows
```

### Supported keys

* `↑` / `↓`: Select the previous or the next option from the list.
* `Enter`: Confirm the selected option.

## ReadInt

Extension to ReadLine to enter a number.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

int number = ConsoleExtensions.ReadInt("ID>", 42, "Invalid ID.");
```

### Output

```
ID>abc
Invalid ID.
ID>42
```

### Supported keys

See supported keys of ReadLine.

## ReadLine

Enable a prompt and default input as an extension to `Console.ReadLine()`.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

string? line = ConsoleExtensions.ReadLine("What is your favorite color? >", "Green");
```

### Output

```
What is your favorite color? >Green
```

### Supported keys

* `Backspace` / `Delete`: Remove one character to the left or right.
* `←` / `→`: Move the cursor to the left or right.
* `Ctrl + ←` / `Ctrl + →`: Move the cursor one word to the left or right.
* `Home` / `End`: Move the cursor to the beginning or the end of the line.
* `Esc`: Clear the line.
* `Ctrl + Z`: Reset the line to the default input.
* `Enter`: Confirm the input.

## ReadPassword

Display a prompt for a password, masking the input.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

string? username = ConsoleExtensions.ReadLine("Username:");
string? password = ConsoleExtensions.ReadPassword("Password:");
```

### Output

```
Username:BorisEetgerink
Password:****************
```

### Supported keys

See supported keys of ReadLine.
