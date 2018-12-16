using System;
using System.IO;

namespace Dna
{
    /// <summary>
    /// Formats messages 
    /// </summary>
    public static class LoggerSourceFormatter
    {
        /// <summary>
        /// Formats the message including the source information
        /// </summary>
        /// <param name="state">The state information about the log</param>
        /// <param name="exception">The exception</param>
        /// <returns></returns>
        public static string Format(object[] state, Exception exception)
        {
            //Get the values from the state
            var origin = (string)state[0];
            var filePath = (string)state[1];
            var lineNumber = (int)state[2];
            var message = (string)state[3];

            //Get any exception message
            var exceptionMessage = exception?.ToString();

            //Add exception to the message if it exists
            if (exception != null)
                exceptionMessage += Environment.NewLine;

            return $" {message}[{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]{System.Environment.NewLine}";
        }
    }
}
