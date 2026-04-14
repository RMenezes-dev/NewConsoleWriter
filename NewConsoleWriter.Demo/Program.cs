using NewConsoleWriter.Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("WriteHeader Examples:");
        Console.WriteLine();

        ConsoleWriter.WriteHeader("Simple UPPERCASE title text", TextTransform.UpperCase);
        Console.WriteLine();

        ConsoleWriter.WriteHeader("A long title text in TITLECASE and with DarkCyan foreground color", 
            ConsoleColor.DarkCyan, TextTransform.TitleCase);
        Console.WriteLine();

        ConsoleWriter.WriteHeader(
            "AlongTITLEtextWITHOUTspacesANDwithDARKREDbackgroundCOLOR",
            ConsoleColor.White,
            ConsoleColor.DarkRed
        );
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("WriteLine Transformations Examples:");
        Console.WriteLine();

        ConsoleWriter.WriteLine(
            "Simple Magenta text", ConsoleColor.Magenta);

        ConsoleWriter.WriteLine(
            "Red TITLECASE text with white background", ConsoleColor.Red, ConsoleColor.White, TextTransform.TitleCase);
        ConsoleWriter.WriteLine(
            "DarkYellow Upper case text", ConsoleColor.DarkYellow, TextTransform.UpperCase);
        ConsoleWriter.WriteLine(
            "DarkGreen Text in LoWeR CASE", ConsoleColor.DarkGreen, TextTransform.LowerCase);
        Console.WriteLine();

        Console.WriteLine();
        Console.WriteLine("WriteLine Semantic Examples:");
        Console.WriteLine();

        ConsoleWriter.WriteLineInfo("Starting routine");

        ConsoleWriter.WriteLineSuccess("Process successfully completed");

        ConsoleWriter.WriteLineWarning("Attention: incomplete data");

        ConsoleWriter.WriteLineError("Error processing file");
        Console.WriteLine();

        Console.ReadKey();
    }
}