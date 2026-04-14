using NewConsoleWriter.Core;

namespace NewConsoleWriter.Tests
{
    [Collection("Console Collection")]
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

        #region HEADER METHODS TESTS
        [Fact]
        public void WriteHeader_Should_Write_Single_Line_For_Short_Text()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteHeader("Title Text");
            });

            var lines = output.ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.Equal(3, lines.Length);
        }

        [Fact]
        public void WriteHeader_Should_Have_Top_And_Bottom_Borders()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteHeader("Test");
            });

            var lines = output.ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.StartsWith("=", lines.First());
            Assert.StartsWith("=", lines.Last());

            Assert.Equal(44, lines.First().Length);
            Assert.Equal(44, lines.Last().Length);
        }

        [Fact]
        public void WriteHeader_All_Lines_Should_Have_44_Characters()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteHeader("The Title Text That is too Big");
            });

            var lines = output.ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                Assert.Equal(44, line.Length);
            }
        }

        [Fact]
        public void WriteHeader_Should_Not_Lose_Text()
        {
            var input = "Very important text for verifying the integrity";

            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteHeader(input);
            });

            foreach (var word in input.Split(' '))
            {
                Assert.Contains(word, output);
            }
        }

        [Fact]
        public void WriteHeader_Should_Handle_Long_Word()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteHeader(new string('A', 60));
            });

            var lines = output.ToString()
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.True(lines.Length > 3);
        }

        [Fact]
        public void WriteHeader_Should_Not_Lose_Content_In_Long_Mixed_Text()
        {
            var input = "1234567890 1234567890123456789012345678901234567890123456789 12345678901234567890";

            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteHeader(input);
            });

            Assert.Contains("1234567890", output);
            Assert.Contains("12345678901234567890", output);
        }

        [Fact]
        public void WriteHeader_ContentLines_Should_Start_And_End_With_Hash_Borders()
        {
            var output = CaptureConsoleOutput(() =>
            {
                ConsoleWriter.WriteHeader("The Title Text is Too long to fit on a Single Line of Output");
            });

            var lines = output
                .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            // Ignore the first and last lines (borders)
            var contentLines = lines.Skip(1).SkipLast(1);

            Assert.NotEmpty(contentLines);

            foreach (var line in contentLines)
            {
                Assert.StartsWith("# ", line);
                Assert.EndsWith(" #", line);
                Assert.Equal(44, line.Length);
            }
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