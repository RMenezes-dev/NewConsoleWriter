using System;

namespace ConsoleWriter.Core
{
    public static class ConsoleWrite
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

        #region PRIVATE METHODS
        private static string ApplyTransform(string text, TextTransform transform)
        {
            if (text == null)
                return string.Empty;

            return transform switch
            {
                TextTransform.UpperCase => text.ToUpperInvariant(),
                _ => text
            };
        }
        #endregion
    }
}
