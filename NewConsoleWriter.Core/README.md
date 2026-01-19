# ConsoleWriter

ConsoleWriter is a lightweight .NET library that simplifies writing colored
and expressive text in console applications and batch processes.

It abstracts console color handling and common text transformations, keeping
application code clean and readable.

## Installation

dotnet add package NewConsoleWriter

## Basic Usage

using NewConsoleWriter.Core;

ConsoleWriter.WriteLine(
    "Process started",
    ConsoleColor.Green
);

ConsoleWriter.WriteLine(
    "ERROR!",
    ConsoleColor.White,
    ConsoleColor.Red
);

## Semantic Methods

ConsoleWriter.WriteLineSuccess("Process finished successfully");

ConsoleWriter.WriteLineWarning("Warning: incomplete data");

ConsoleWriter.WriteLineError("Error while processing file");

ConsoleWriter.WriteLineInfo("Starting routine");

## Text Transformations

ConsoleWriter.WriteLine(
    "error occurred in the system",
    ConsoleColor.Red,
    TextTransform.TitleCase
);

Available transformations:
- None
- UpperCase
- LowerCase
- TitleCase

## Features

- Write text with foreground color
- Write text with foreground and background colors
- Semantic methods for common message types
- Optional text transformations
- Automatic restoration of console colors

## Notes

- Console color support depends on the terminal being used.
- Background colors may not be supported in all environments.
- Designed for console and batch applications only.

## Repository

Source code and issues:
https://github.com/RMenezes-dev/NewConsoleWriter
