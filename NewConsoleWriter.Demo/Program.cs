using NewConsoleWriter.Core;

class Program
{
    static void Main()
    {
        Console.WriteLine("Texto normal");

        ConsoleWriter.WriteLine(
            "Texto verde", ConsoleColor.Green);

        ConsoleWriter.WriteLine(
            "Texto vermelho com fundo branco", ConsoleColor.Red, ConsoleColor.White);

        ConsoleWriter.WriteLine(
            "Upper case", ConsoleColor.Yellow, TextTransform.UpperCase);

        Console.WriteLine("Texto normal novamente");

        Console.ReadKey();
    }
}