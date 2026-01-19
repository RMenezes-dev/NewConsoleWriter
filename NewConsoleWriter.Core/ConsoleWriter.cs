using System;
using System.Globalization;

namespace NewConsoleWriter.Core
{
    public static class ConsoleWriter
    {
        #region GENERIC METHODS
        public static void Write(
            string text,
            ConsoleColor foreground,
            TextTransform transform = TextTransform.None)
        {
            var originalForeground = Console.ForegroundColor;

            try
            {
                Console.ForegroundColor = foreground;
                Console.Write(ApplyTransform(text, transform));
            }
            finally
            {
                Console.ForegroundColor = originalForeground;
            }
        }

        public static void Write(
            string text,
            ConsoleColor foreground,
            ConsoleColor background,
            TextTransform transform = TextTransform.None)
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            try
            {
                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
                Console.Write(ApplyTransform(text, transform));
            }
            finally
            {
                Console.ForegroundColor = originalForeground;
                Console.BackgroundColor = originalBackground;
            }
        }

        public static void WriteLine(
            string text,
            ConsoleColor foreground,
            TextTransform transform = TextTransform.None)
        {
            var originalForeground = Console.ForegroundColor;

            try
            {
                Console.ForegroundColor = foreground;
                Console.WriteLine(ApplyTransform(text, transform));
            }
            finally
            {
                Console.ForegroundColor = originalForeground;
            }
        }

        public static void WriteLine(
            string text,
            ConsoleColor foreground,
            ConsoleColor background,
            TextTransform transform = TextTransform.None)
        {
            var originalForeground = Console.ForegroundColor;
            var originalBackground = Console.BackgroundColor;

            try
            {
                Console.ForegroundColor = foreground;
                Console.BackgroundColor = background;
                Console.WriteLine(ApplyTransform(text, transform));
            }
            finally
            {
                Console.ForegroundColor = originalForeground;
                Console.BackgroundColor = originalBackground;
            }
        }
        #endregion

        #region SEMANTIC METHODS
        public static void WriteInfo(string text)
        {
            Write(text, ConsoleColor.Blue);
        }

        public static void WriteLineInfo(string text)
        {
            WriteLine(text, ConsoleColor.Blue);
        }

        public static void WriteSuccess(string text)
        {
            Write(text, ConsoleColor.Green);
        }

        public static void WriteLineSuccess(string text)
        {
            WriteLine(text, ConsoleColor.Green);
        }

        public static void WriteWarning(string text)
        {
            Write(text, ConsoleColor.Yellow);
        }

        public static void WriteLineWarning(string text)
        {
            WriteLine(text, ConsoleColor.Yellow);
        }

        public static void WriteError(string text)
        {
            Write(text, ConsoleColor.Red);
        }

        public static void WriteLineError(string text)
        {
            WriteLine(text, ConsoleColor.Red);
        }
        #endregion

        #region PRIVATE METHODS
        private static string ApplyTransform(string text, TextTransform transform)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return transform switch
            {
                TextTransform.UpperCase =>
                    text.ToUpperInvariant(),

                TextTransform.LowerCase =>
                    text.ToLowerInvariant(),

                TextTransform.TitleCase =>
                    CultureInfo.InvariantCulture.TextInfo
                        .ToTitleCase(text.ToLowerInvariant()),

                _ => text
            };
        }
        #endregion
    }
}
