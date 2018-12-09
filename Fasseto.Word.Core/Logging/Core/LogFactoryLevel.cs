using System;
using System.Collections.Generic;
using System.Text;

namespace Fasseto.Word.Core
{

    /// <summary>
    /// The level of details to output for the logger
    /// </summary>
    public enum LogOutputLevel
    {
        /// <summary>
        /// Logs eveything
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Log all information except debug information
        /// </summary>
        Verbose = 2,

        /// <summary>
        /// Log all informative messages, ignoring all Debug and Verbose messages
        /// </summary>
        Informative = 3,

        /// <summary>
        /// Log only critical errors and warnings, no general information
        /// </summary>
        Critical = 4,

        /// <summary>
        /// The logger will never output anything
        /// </summary>
        Nothing = 7
    }
}
