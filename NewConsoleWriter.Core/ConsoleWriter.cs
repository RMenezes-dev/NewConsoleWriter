using System;
using System.Globalization;

namespace NewConsoleWriter.Core
{
    public static class ConsoleWriter
    {
        #region GENERIC METHODS
        /// <summary>
        /// Writes text to the console using the specified foreground color
        /// and applies an optional text transformation,
        /// without appending a new line.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="foreground">The foreground color of the text.</param>
        /// <param name="transform">Optional text transformation to apply.</param>
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

        /// <summary>
        /// Writes text to the console using the specified foreground and background colors
        /// and applies an optional text transformation,
        /// without appending a new line.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="foreground">The foreground color of the text.</param>
        /// <param name="background">The background color of the text.</param>
        /// <param name="transform">Optional text transformation to apply.</param>
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

        /// <summary>
        /// Writes text to the console using the specified foreground color
        /// and applies an optional text transformation,
        /// then appends a new line.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="foreground">The foreground color of the text.</param>
        /// <param name="transform">Optional text transformation to apply.</param>
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

        /// <summary>
        /// Writes text to the console using the specified foreground and background colors
        /// and applies an optional text transformation,
        /// then appends a new line.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        /// <param name="foreground">The foreground color of the text.</param>
        /// <param name="background">The background color of the text.</param>
        /// <param name="transform">Optional text transformation to apply.</param>
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
        /// <summary>
        /// Writes an informational message to the console using a predefined color,
        /// without appending a new line.
        /// </summary>
        /// <param name="text">The informational message to be written.</param>

        public static void WriteInfo(string text)
        {
            Write(text, ConsoleColor.Blue);
        }

        /// <summary>
        /// Writes an informational message to the console using a predefined color
        /// and appends a new line.
        /// </summary>
        /// <param name="text">The informational message to be written.</param>

        public static void WriteLineInfo(string text)
        {
            WriteLine(text, ConsoleColor.Blue);
        }

        /// <summary>
        /// Writes a success message to the console using a predefined color,
        /// without appending a new line.
        /// </summary>
        /// <param name="text">The success message to be written.</param>
        public static void WriteSuccess(string text)
        {
            Write(text, ConsoleColor.Green);
        }

        /// <summary>
        /// Writes a success message to the console using a predefined color
        /// and appends a new line.
        /// </summary>
        /// <param name="text">The success message to be written.</param>
        public static void WriteLineSuccess(string text)
        {
            WriteLine(text, ConsoleColor.Green);
        }

        /// <summary>
        /// Writes a warning message to the console using a predefined color,
        /// without appending a new line.
        /// </summary>
        /// <param name="text">The warning message to be written.</param>
        public static void WriteWarning(string text)
        {
            Write(text, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Writes a warning message to the console using a predefined color
        /// and appends a new line.
        /// </summary>
        /// <param name="text">The warning message to be written.</param>

        public static void WriteLineWarning(string text)
        {
            WriteLine(text, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Writes an error message to the console using a predefined color,
        /// without appending a new line.
        /// </summary>
        /// <param name="text">The error message to be written.</param>

        public static void WriteError(string text)
        {
            Write(text, ConsoleColor.Red);
        }

        /// <summary>
        /// Writes an error message to the console using a predefined color
        /// and appends a new line.
        /// </summary>
        /// <param name="text">The error message to be written.</param>

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
