using System;
using System.Collections.Concurrent;
using System.IO;
using Microsoft.Extensions.Logging;

namespace Dna
{
    public class FileLogger : ILogger
    {
        #region Static Properties

        /// <summary>
        /// List of locks based on a filepath
        /// </summary>
        protected static ConcurrentDictionary<string, object> mLocks = new ConcurrentDictionary<string, object>();

        #endregion

        #region Protected Properties

        /// <summary>
        /// Category Name of this file logger
        /// </summary>
        protected readonly string mCategoryName;

        /// <summary>
        /// FilePath of this file logger to write to 
        /// </summary>
        protected readonly string mFilePath;

        /// <summary>
        /// File Logger configuration
        /// </summary>
        protected readonly FileLoggerConfiguration mConfiguration;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="categoryName">The category for this logger</param>
        /// <param name="filepath">The file path to write to</param>
        /// <param name="configuration">The configuration to use</param>
        public FileLogger(string categoryName, string filepath, FileLoggerConfiguration configuration)
        {
            mCategoryName = categoryName;
            mFilePath = filepath;
            mConfiguration = configuration;
        }

        #endregion

        /// <summary>
        /// File loggers are not scoped
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="state"></param>
        /// <returns></returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <summary>
        /// Enabled if the log level is the same or greater
        /// </summary>
        /// <param name="logLevel">LogLevel to check against</param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= mConfiguration.LogLevel;
        }

        /// <summary>
        /// Logs message to file
        /// </summary>
        /// <typeparam name="TState">The type of the details of the message</typeparam>
        /// <param name="logLevel">The log level</param>
        /// <param name="eventId">The Id</param>
        /// <param name="state">The details of the message</param>
        /// <param name="exception">Any exceptions to log</param>
        /// <param name="formatter">The formatter for converting the state and exception to a message</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");

            //Get the formatted message
            var message = formatter(state, exception);

            var output = $"[{currentTime}]  {message}{Environment.NewLine}";

            //Normalize and Absolute the path
            //TODO: Make use of configuration base path
            var normalizePath = Path.GetFullPath(mFilePath).ToUpper();

            var fileLock = mLocks.GetOrAdd(normalizePath, path => new object());

            //Lock the file
            lock (fileLock)
            {
                File.AppendAllText(normalizePath, output);
            }
        }
    }
}
