using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Logs a message to the debug window
    /// </summary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        public void Log(string message, LogLevel level)
        {
            var category = "";

            switch (level)
            {
                case LogLevel.Debug:
                    category = "information";
                    break;
                case LogLevel.Verbose:
                    category = "verbose";
                    break;
                case LogLevel.Warning:
                    category = "warning";
                    break;
                case LogLevel.Error:
                    category = "error";
                    break;
                case LogLevel.Success:
                    category = "-----";
                    break;
            }

            //write a message to the console
            Debug.WriteLine(message, category);
        }
    }
}
