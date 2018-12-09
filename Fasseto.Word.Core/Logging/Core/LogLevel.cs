namespace Fasseto.Word.Core
{

    /// <summary>
    /// The severity of the log message
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Developer specific information
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Verbose information
        /// </summary>
        Verbose = 2,

        /// <summary>
        /// General Information
        /// </summary>
        Informative = 3,

        /// <summary>
        /// A warning
        /// </summary>
        Warning = 4,

        /// <summary>
        /// Error
        /// </summary>
        Error = 5,

        /// <summary>
        /// Success
        /// </summary>
        Success = 6

    }
}
