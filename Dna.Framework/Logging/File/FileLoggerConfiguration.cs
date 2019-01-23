using Microsoft.Extensions.Logging;

namespace Dna
{
    /// <summary>
    /// The configuration for a <see cref="FileLogger"/>
    /// </summary>
    public class FileLoggerConfiguration
    {
        #region Public Properties

        /// <summary>
        /// The Level of log that should be processed
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Trace;

        /// <summary>
        /// Whether to log the time or not
        /// </summary>
        public bool LogTime { get; set; } = true;

        #endregion
    }
}
