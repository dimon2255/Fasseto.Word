using System;
using System.Runtime.CompilerServices;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Holds a bunch of loggers to log mesages for the user
    /// </summary>
    public interface ILogFactory
    {
        #region Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        event Action<(string Message, LogLevel Level)> NewLog;
        
        #endregion

        #region Properties

        /// <summary>
        /// The level of logging to output
        /// </summary>
        LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the origin of where the log message was logged from
        /// </summary>
        bool IncludeLogOriginDetails { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a specific logger to this factory
        /// </summary>
        /// <param name="logger">the logger</param>
        void AddLogger(ILogger logger);

        /// <summary>
        /// Removes the soecified logger from  this factory
        /// </summary>
        /// <param name="logger">The logger</param>
        void RemoveLogger(ILogger logger);
        
        /// <summary>
        /// Logs the specific message to all loggers in this factory
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="level">The level of message everity</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        void Log(string message, 
                    LogLevel level = LogLevel.Informative, 
                    [CallerMemberName]string origin = "", 
                    [CallerFilePath]string filepath = "", 
                    [CallerLineNumber]int lineNumber = 0);

        #endregion
    }
}
