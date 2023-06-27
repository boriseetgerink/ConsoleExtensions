# .NET Console Extensions

Various console extensions.

## ReadLine

Enable a prompt and default input as an extension to `Console.ReadLine()`.

### Usage

```csharp
using BorisEetgerink.ConsoleExtensions;

string? line = ConsoleExtensions.ReadLine("What is your favorite color?>", "Green");
```

### Supported keys

* `←` / `→`: move the cursor left or right.
* `Ctrl + ←` / `Ctrl + →`: move the cursor one word left or right.
* `Home` / `End`: Move the cursor to the beginning or the end of the line.
* `Esc`: Clear the line.
* `Ctrl + Z`: Reset the line to the default input.
