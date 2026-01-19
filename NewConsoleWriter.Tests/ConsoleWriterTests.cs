using System;
using System.IO;
using Xunit;
using NewConsoleWriter.Core;

namespace NewConsoleWriter.Tests
{
    public class ConsoleWriterTests
    {
        #region GENERIC METHODS TESTS
        [Fact]
        public void WriteLine_Writes_Text_With_NewLine()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLine("Teste", ConsoleColor.Green);
            });

            Assert.Equal("Teste" + Environment.NewLine, output);
        }

        [Fact]
        public void WriteLine_UpperCase_Transforms_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLine(
                    "teste",
                    ConsoleColor.Green,
                    TextTransform.UpperCase
                );
            });

            Assert.Equal("TESTE" + Environment.NewLine, output);
        }

        [Fact]
        public void WriteLine_LowerCase_Transforms_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLine(
                    "TeStE",
                    ConsoleColor.Green,
                    TextTransform.LowerCase
                );
            });

            Assert.Equal("teste" + Environment.NewLine, output);
        }

        [Fact]
        public void WriteLine_TitleCase_Transforms_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLine(
                    "erro crítico no sistema",
                    ConsoleColor.Red,
                    TextTransform.TitleCase
                );
            });

            Assert.Equal(
                "Erro Crítico No Sistema" + Environment.NewLine,
                output
            );
        }

        [Fact]
        public void WriteLine_Restores_Console_Colors()
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLine(
                    "Erro",
                    ConsoleColor.White,
                    ConsoleColor.Red
                );
            });

            Assert.Equal(originalForeground, Console.ForegroundColor);
            Assert.Equal(originalBackground, Console.BackgroundColor);
        }
        #endregion

        #region SEMANTIC METHODS TESTS
        [Fact]
        public void WriteLineInfo_Writes_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLineInfo("Information Text");
            });

            Assert.Equal(
                "Information Text" + Environment.NewLine,
                output
            );
        }

        [Fact]
        public void WriteLineSuccess_Writes_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLineSuccess("Success Text");
            });

            Assert.Equal(
                "Success Text" + Environment.NewLine,
                output
            );
        }

        [Fact]
        public void WriteLineWarning_Writes_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLineWarning("Warning Text");
            });

            Assert.Equal(
                "Warning Text" + Environment.NewLine,
                output
            );
        }

        [Fact]
        public void WriteLineError_Writes_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLineError("Error Text");
            });

            Assert.Equal(
                "Error Text" + Environment.NewLine,
                output
            );
        }
        #endregion

        #region TESTS HELPER
        private static string CaptureConsoleOutput(Action action)
        {
            var originalOut = Console.Out;
            var writer = new StringWriter();

            try
            {
                Console.SetOut(writer);
                action();
                return writer.ToString();
            }
            finally
            {
                Console.SetOut(originalOut);
            }
        }
        #endregion
    }
}