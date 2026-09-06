# GradeTrackerCLI ₊˚⊹

## Features ˚₊‧
* **Interactive Menu:** Simple CLI options to navigate between adding records, viewing data, and exiting.
* **Input Parsing:** Cleans up comma-separated grade inputs using LINQ.
* **Automatic Evaluation:** Uses modern C# switch pattern matching to convert decimal averages into letter marks (A+, B, etc.).
* **Data Storage:** Stores student information cleanly in memory using dictionaries and tuples.

## Key Concepts Learned ˚₊‧
* `string.Split()` to break apart delimited user strings into manageable arrays.
* `string.Empty` & `string.IsNullOrWhiteSpace()` for safe string initialization and input validation.
* `LINQ .Select()` for projecting and transforming data sequences.
* **C# Value Tuples** `(decimal grade, string mark)` to bundle related data without writing full custom classes.
* **Pattern Matching Switch Expressions** to cleanly map value ranges to grade letters.


## How to Run ‧₊˚

1. Create a new folder and open it in VS Code.
2. Run `dotnet new console` in the terminal.
3. Replace `Program.cs` with the source code.
4. Run with `dotnet run`. ♡