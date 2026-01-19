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
                ConsoleWriter.WriteLine("WriteLine Test", ConsoleColor.Green);
            });

            Assert.Equal("WriteLine Test" + Environment.NewLine, output);
        }

        [Fact]
        public void WriteLine_UpperCase_Transforms_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLine(
                    "UpperCase Test",
                    ConsoleColor.Green,
                    TextTransform.UpperCase
                );
            });

            Assert.Equal("UPPERCASE TEST" + Environment.NewLine, output);
        }

        [Fact]
        public void WriteLine_LowerCase_Transforms_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLine(
                    "LowERcaSe TeSt",
                    ConsoleColor.Green,
                    TextTransform.LowerCase
                );
            });

            Assert.Equal("lowercase test" + Environment.NewLine, output);
        }

        [Fact]
        public void WriteLine_TitleCase_Transforms_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteLine(
                    "the titlecase test",
                    ConsoleColor.Red,
                    TextTransform.TitleCase
                );
            });

            Assert.Equal(
                "The Titlecase Test" + Environment.NewLine,
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
                    "Error Message",
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