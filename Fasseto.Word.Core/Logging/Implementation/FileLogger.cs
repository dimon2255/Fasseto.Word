using System;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Logs to a specific file
    /// </summary>
    public class FileLogger : ILogger
    {
        #region Public Properties

        /// <summary>
        /// Path of the file to log to
        /// </summary>
        public string FilePath { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="filePath">File path to log messages to</param>
        public FileLogger(string filePath)
        {
            FilePath = filePath;
        }

        #endregion

        #region Logger Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public void Log(string message, LogLevel level)
        {
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");

            CoreDI.FileManager.WriteTextToFileAsync($"[{currentTime}]" + message, FilePath, append: true);
        }

        #endregion

    }
}
