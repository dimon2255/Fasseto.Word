using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Dna
{
    /// <summary>
    /// Provides the ability to log to a file
    /// </summary>
    public class FileLoggerProvider : ILoggerProvider
    {
        #region  Protected Properties

        /// <summary>
        /// Configuration to use when creating loggers
        /// </summary>
        protected readonly FileLoggerConfiguration mConfiguration;

        /// <summary>
        /// FilePath for FileLogger to log messages to
        /// </summary>
        protected readonly string mFilePath;

        /// <summary>
        /// Keeps track of the loggers already created.
        /// </summary>
        protected readonly ConcurrentDictionary<string, FileLogger> mLoggers = new ConcurrentDictionary<string, FileLogger>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="filepath">filepath to log to</param>
        public FileLoggerProvider(string filepath, FileLoggerConfiguration configuration)
        {
            mConfiguration = configuration;
            mFilePath = filepath;
        }

        #endregion


        #region ILoggerProvider Implementation

        /// <summary>
        /// Creates a custom logger bases on a category name
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            //get or create a logger for this category
            return mLoggers.GetOrAdd(categoryName, name => new FileLogger(name, mFilePath, mConfiguration));
        }

        /// <summary>
        /// Disposes of loggers
        /// </summary>
        public void Dispose()
        {
            mLoggers.Clear();
        }

        #endregion
    }
}
