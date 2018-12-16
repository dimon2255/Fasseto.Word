using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;

namespace Dna
{
    /// <summary>
    /// Extension methods for <see cref="ILogger"/>
    /// </summary>
    public static class LoggerExtensions
    {
        /// <summary>
        /// Logs a critical message, including the source of the log 
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="message">The caller's member function</param>
        /// <param name="eventId">EventId</param>
        /// <exception cref="Exception">Exception</exception>
        /// <param name="origin">The source code file</param>
        /// <param name="filepath">The source code file path</param>
        /// <param name="lineNumber">The line number of the caller</param>
        /// <param name="args">Additional arguments</param>
        public static void LogCriticalSource(
                    this ILogger logger,
                    string message,
                    EventId eventId = new EventId(),
                    Exception exception = null,
                    [CallerMemberName]string origin = "",
                    [CallerFilePath]string filepath = "",
                    [CallerLineNumber]int lineNumber = 0,
                    params object[] args) => logger.Log(LogLevel.Critical, 
                                                        eventId, 
                                                        args.Prepend(origin, filepath, lineNumber, message), 
                                                        exception, 
                                                        LoggerSourceFormatter.Format);
    }
}
