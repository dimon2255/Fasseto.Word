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


        /// <summary>
        /// Logs a debug message, including the source of the log 
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="message">The caller's member function</param>
        /// <param name="eventId">EventId</param>
        /// <exception cref="Exception">Exception</exception>
        /// <param name="origin">The source code file</param>
        /// <param name="filepath">The source code file path</param>
        /// <param name="lineNumber">The line number of the caller</param>
        /// <param name="args">Additional arguments</param>
        public static void LogDebugSource(
                    this ILogger logger,
                    string message,
                    EventId eventId = new EventId(),
                    Exception exception = null,
                    [CallerMemberName]string origin = "",
                    [CallerFilePath]string filepath = "",
                    [CallerLineNumber]int lineNumber = 0,
                    params object[] args) => logger.Log(LogLevel.Debug,
                                                        eventId,
                                                        args.Prepend(origin, filepath, lineNumber, message),
                                                        exception,
                                                        LoggerSourceFormatter.Format);

        /// <summary>
        /// Logs a error message, including the source of the log 
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="message">The caller's member function</param>
        /// <param name="eventId">EventId</param>
        /// <exception cref="Exception">Exception</exception>
        /// <param name="origin">The source code file</param>
        /// <param name="filepath">The source code file path</param>
        /// <param name="lineNumber">The line number of the caller</param>
        /// <param name="args">Additional arguments</param>
        public static void LogErrorSource(
                    this ILogger logger,
                    string message,
                    EventId eventId = new EventId(),
                    Exception exception = null,
                    [CallerMemberName]string origin = "",
                    [CallerFilePath]string filepath = "",
                    [CallerLineNumber]int lineNumber = 0,
                    params object[] args) => logger.Log(LogLevel.Error,
                                                        eventId,
                                                        args.Prepend(origin, filepath, lineNumber, message),
                                                        exception,
                                                        LoggerSourceFormatter.Format);


        /// <summary>
        /// Logs an information source message, including the source of the log 
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="message">The caller's member function</param>
        /// <param name="eventId">EventId</param>
        /// <exception cref="Exception">Exception</exception>
        /// <param name="origin">The source code file</param>
        /// <param name="filepath">The source code file path</param>
        /// <param name="lineNumber">The line number of the caller</param>
        /// <param name="args">Additional arguments</param>
        public static void LogInformationSource(
                    this ILogger logger,
                    string message,
                    EventId eventId = new EventId(),
                    Exception exception = null,
                    [CallerMemberName]string origin = "",
                    [CallerFilePath]string filepath = "",
                    [CallerLineNumber]int lineNumber = 0,
                    params object[] args) => logger.Log(LogLevel.Information,
                                                        eventId,
                                                        args.Prepend(origin, filepath, lineNumber, message),
                                                        exception,
                                                        LoggerSourceFormatter.Format);


        /// <summary>
        /// Logs an trace source message, including the source of the log 
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="message">The caller's member function</param>
        /// <param name="eventId">EventId</param>
        /// <exception cref="Exception">Exception</exception>
        /// <param name="origin">The source code file</param>
        /// <param name="filepath">The source code file path</param>
        /// <param name="lineNumber">The line number of the caller</param>
        /// <param name="args">Additional arguments</param>
        public static void LogTraceSource(
                    this ILogger logger,
                    string message,
                    EventId eventId = new EventId(),
                    Exception exception = null,
                    [CallerMemberName]string origin = "",
                    [CallerFilePath]string filepath = "",
                    [CallerLineNumber]int lineNumber = 0,
                    params object[] args) => logger.Log(LogLevel.Trace,
                                                        eventId,
                                                        args.Prepend(origin, filepath, lineNumber, message),
                                                        exception,
                                                        LoggerSourceFormatter.Format);


        /// <summary>
        /// Logs a warning source message, including the source of the log 
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="message">The caller's member function</param>
        /// <param name="eventId">EventId</param>
        /// <exception cref="Exception">Exception</exception>
        /// <param name="origin">The source code file</param>
        /// <param name="filepath">The source code file path</param>
        /// <param name="lineNumber">The line number of the caller</param>
        /// <param name="args">Additional arguments</param>
        public static void LogWarningSource(
                    this ILogger logger,
                    string message,
                    EventId eventId = new EventId(),
                    Exception exception = null,
                    [CallerMemberName]string origin = "",
                    [CallerFilePath]string filepath = "",
                    [CallerLineNumber]int lineNumber = 0,
                    params object[] args) => logger.Log(LogLevel.Warning,
                                                        eventId,
                                                        args.Prepend(origin, filepath, lineNumber, message),
                                                        exception,
                                                        LoggerSourceFormatter.Format);
    }
}
