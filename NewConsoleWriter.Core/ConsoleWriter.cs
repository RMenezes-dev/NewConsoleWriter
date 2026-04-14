using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NewConsoleWriter.Core
{
    public static class ConsoleWriter
    {
        #region PRIVATE CONSTANTS
        private const int HeaderWidth = 44;
        private const int ContentWidth = 40;
        private const int AcceptableDifference = 3;
        private const char BorderChar = '=';
        #endregion

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

        #region WRITING PRIVATE METHODS
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

        #region HEADER METHODS
        /// <summary>
        /// Writes a formatted header with a fixed width and optional text transformation.
        /// </summary>
        /// <param name="text">The header text.</param>
        /// <param name="transform">The text transformation to apply.</param>
        public static void WriteHeader(
            string text,
            TextTransform transform = TextTransform.None)
        {
            WriteHeader(
                text,
                Console.ForegroundColor,
                Console.BackgroundColor,
                transform
            );
        }

        /// <summary>
        /// Writes a formatted header with a fixed width, using the specified
        /// foreground color and optional text transformation.
        /// </summary>
        /// <param name="text">The header text.</param>
        /// <param name="foreground">The foreground color of the header.</param>
        /// <param name="transform">The text transformation to apply.</param>
        public static void WriteHeader(
            string text,
            ConsoleColor foreground,
            TextTransform transform = TextTransform.None)
        {
            WriteHeader(
                text,
                foreground,
                Console.BackgroundColor,
                transform
            );
        }

        /// <summary>
        /// Writes a formatted header with a fixed width, using the specified
        /// foreground and background colors and optional text transformation.
        /// </summary>
        /// <param name="text">The header text.</param>
        /// <param name="foreground">The foreground color of the header.</param>
        /// <param name="background">The background color of the header.</param>
        /// <param name="transform">The text transformation to apply.</param>
        public static void WriteHeader(
            string text,
            ConsoleColor foreground,
            ConsoleColor background,
            TextTransform transform = TextTransform.None)
        {
            var sanitized = SanitizeText(text);

            if (string.IsNullOrEmpty(sanitized))
                return;

            var transformed = ApplyTransform(sanitized, transform);

            var lines = BuildBalancedLines(transformed);

            var border = new string(BorderChar, HeaderWidth);

            WriteLine(border, foreground, background);

            foreach (var line in lines)
            {
                var headerLine = BuildHeaderLine(line);
                WriteLine(headerLine, foreground, background);
            }

            WriteLine(border, foreground, background);
        }
        #endregion

        #region HEADER PRIVATE METHODS
        private static string SanitizeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            // Replace line breaks and tabs with spaces
            var sanitized = text
                .Replace('\r', ' ')
                .Replace('\n', ' ')
                .Replace('\t', ' ')
                .Trim();

            // Normalize multiple spaces into a single space
            while (sanitized.Contains("  "))
                sanitized = sanitized.Replace("  ", " ");

            return sanitized;
        }

        private static IEnumerable<string> SplitLongWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                yield break;

            if (word.Length <= ContentWidth)
            {
                yield return word;
                yield break;
            }

            var mid = word.Length / 2;

            var left = word.Substring(0, mid);
            var right = word.Substring(mid);

            foreach (var part in SplitLongWord(left))
                yield return part;

            foreach (var part in SplitLongWord(right))
                yield return part;
        }

        private static List<string> BuildBalancedLines(string text)
        {
            if (string.IsNullOrEmpty(text))
                return new List<string>();

            if (text.Length <= ContentWidth)
                return new List<string> { text };

            var words = new Queue<string>();

            foreach (var word in text.Split(' '))
            {
                foreach (var part in SplitLongWord(word))
                {
                    words.Enqueue(part);
                }
            }

            var totalChars = words.Sum(w => w.Length) + (words.Count - 1);
            var estimatedLines = (int)Math.Ceiling((double)totalChars / ContentWidth);

            List<string> result;

            do
            {
                result = new List<string>();

                var wordsCopy = new Queue<string>(words);

                var baseTarget =
                    (int)Math.Ceiling((double)totalChars / estimatedLines);

                var targetLength = Math.Min(
                    baseTarget + AcceptableDifference,
                    ContentWidth
                );

                while (wordsCopy.Count > 0)
                {
                    var currentLine = string.Empty;

                    while (wordsCopy.Count > 0)
                    {
                        var nextWord = wordsCopy.Peek();

                        var tentativeLength = currentLine.Length == 0
                            ? nextWord.Length
                            : currentLine.Length + 1 + nextWord.Length;

                        if (tentativeLength > ContentWidth)
                            break;

                        if (currentLine.Length > 0 && tentativeLength > targetLength)
                            break;

                        wordsCopy.Dequeue();

                        currentLine = currentLine.Length == 0
                            ? nextWord
                            : currentLine + " " + nextWord;
                    }

                    result.Add(currentLine);
                }

                // Retry if more lines were produced than expected
                if (result.Count > estimatedLines)
                    estimatedLines++;
                else
                    break;
            }
            while (true);

            return result;
        }


        private static string CenterText(string text)
        {
            text ??= string.Empty;

            if (text.Length >= ContentWidth)
                return text;

            var totalPadding = ContentWidth - text.Length;
            var leftPadding = totalPadding / 2;
            var rightPadding = totalPadding - leftPadding;

            return new string(' ', leftPadding) +
                   text +
                   new string(' ', rightPadding);
        }

        private static string BuildHeaderLine(string content)
        {
            content ??= string.Empty;

            if (content.Length < ContentWidth)
                content = CenterText(content);

            return $"# {content} #";
        }
        #endregion
    }
}
