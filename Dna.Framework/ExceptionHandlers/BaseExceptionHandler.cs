using System;

namespace Dna
{
    /// <summary>
    /// Handles all exceptions, simply logging them to a logger
    /// </summary>
    public class BaseExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Handles exceptions
        /// </summary>
        /// <param name="exception">Exception to handle</param>
        public void HandleError(Exception exception)
        {
            //Log it
            //TODO: Localization of strings
            Framework.Logger.LogCriticalSource("Unhandled exception occurred", exception: exception);

        }
    }
}
