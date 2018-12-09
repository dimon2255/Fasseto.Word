using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Logs the messages to the console
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Logs the given message to the system console
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="level">level of the message</param>
        public void Log(string message, LogLevel level)
        {
            //Save old color
            var oldColor = Console.ForegroundColor;

            //Default log console color
            var consoleColor = ConsoleColor.White;

            switch (level)
            {
                case LogLevel.Debug:
                    consoleColor = ConsoleColor.Blue;
                    break;

                case LogLevel.Verbose:
                    consoleColor = ConsoleColor.Gray;
                    break;

                case LogLevel.Warning:
                    consoleColor = ConsoleColor.DarkYellow;
                    break;

                case LogLevel.Error:
                    consoleColor = ConsoleColor.Red;
                    break;

                case LogLevel.Success:
                    consoleColor = ConsoleColor.Red;
                    break;
            }

            Console.ForegroundColor = consoleColor;

            //Write a message to the console
            Console.WriteLine(message);

            //Reset old color after logging a message
            Console.ForegroundColor = oldColor;
        }
    }
}
