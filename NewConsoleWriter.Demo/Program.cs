using NewConsoleWriter.Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("Regular text");
        Console.WriteLine();

        ConsoleWriter.WriteLine(
            "Green text", ConsoleColor.Green);

        ConsoleWriter.WriteLine(
            "Red text with white background", ConsoleColor.Red, ConsoleColor.White);

        ConsoleWriter.WriteLine(
            "Upper case text", ConsoleColor.Yellow, TextTransform.UpperCase);

        ConsoleWriter.WriteLine(
            "Text in MiXed CaSe To GO tO LoWeR", ConsoleColor.Yellow, TextTransform.LowerCase);

        ConsoleWriter.WriteLine(
            "system critical error", ConsoleColor.Red, TextTransform.TitleCase);

        ConsoleWriter.WriteLine(
            "PROCESSING COMPLETED", ConsoleColor.Green, TextTransform.TitleCase);

        Console.WriteLine("Regular text");
        Console.WriteLine();

        ConsoleWriter.WriteLineInfo("Starting routine");
        ConsoleWriter.WriteLineSuccess("Process successfully completed");
        ConsoleWriter.WriteLineWarning("Attention: incomplete data");
        ConsoleWriter.WriteLineError("Error processing file");
        Console.WriteLine();

        Console.WriteLine("Regular text");

        Console.ReadKey();
    }
}