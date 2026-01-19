namespace NewConsoleWriter.Core
{
    /// <summary>
    /// Defines optional text transformations that can be applied
    /// before writing text to the console.
    /// </summary>
    public enum TextTransform
    {
        /// <summary>
        /// No text transformation is applied.
        /// </summary>
        None,

        /// <summary>
        /// Converts all characters to upper case.
        /// </summary>
        UpperCase,

        /// <summary>
        /// Converts all characters to lower case.
        /// </summary>
        LowerCase,

        /// <summary>
        /// Converts text to title case using invariant culture.
        /// </summary>
        TitleCase
    }
}
