# .NET Console Extensions

Various console extensions.

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
