using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The standard log factory for Fasseto Word
    /// Logs details to the Console
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Properties

        /// <summary>
        /// The list of loggers in this factory
        /// </summary>
        protected List<ILogger> mLoggers = new List<ILogger>();

        /// <summary>
        /// Lock locking logger list to keep it thread safe
        /// </summary>
        protected object mLoggersLock = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// The level of logging to output
        /// </summary>
        public LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// If true, includes the origin of where the log message was logged from
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion

        #region Public Events

        /// <summary>
        /// Fires whenever a new log arrives
        /// </summary>
        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        #endregion


        #region Constructors

        public BaseLogFactory(ILogger[] loggers = null)
        {
            //Add a console Logger by default
            AddLogger(new DebugLogger());

            //Add any other loggers pased in, if any
            if(loggers != null)
                mLoggers.AddRange(loggers);
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds a specific logger to this factory
        /// </summary>
        /// <param name="logger">the logger</param>
        public void AddLogger(ILogger logger)
        {
            lock (mLoggersLock)
            {
                if(!mLoggers.Contains(logger))
                    mLoggers.Add(logger);
            }
        }

        /// <summary>
        /// Removes the specified logger from  this factory
        /// </summary>
        /// <param name="logger">The logger</param>
        public void RemoveLogger(ILogger logger)
        {
            lock (mLoggersLock)
            {
                if (mLoggers.Contains(logger))
                    mLoggers.Remove(logger);
            }
        }

        /// <summary>
        /// Logs the specific message to all loggers in this factory
        /// </summary>
        /// <param name="message">Message to log</param>
        /// <param name="level">The level of message severity</param>
        /// <param name="origin">The method/function this message was logged in</param>
        /// <param name="filepath">The code filename that this message was logged from</param>
        /// <param name="lineNumber">The line of code in the filename this message was logged from</param>
        public void Log(string message, 
                        LogLevel level = LogLevel.Informative, 
                        [CallerMemberName]string origin = "",
                        [CallerFilePath]string filepath = "", 
                        [CallerLineNumber]int lineNumber = 0)
        {
            //Obey Log output Level
            if ((int)level < (int)LogOutputLevel)
                return;

            if (IncludeLogOriginDetails)
            {
                message = $" {message}[{Path.GetFileName(filepath)} > {origin}() > Line {lineNumber}]{Environment.NewLine}";
            }

            //Log to all loggers
            mLoggers.ForEach(logger => logger.Log(message, level));

            //Notify all listeners
            NewLog.Invoke((message, level));
        }

        #endregion

    }
}
