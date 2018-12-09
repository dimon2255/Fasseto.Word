namespace Fasseto.Word.Core
{
    /// <summary>
    /// A logger that will handle log message from a <see cref="ILogFactory"/> 
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Handles the logged message passed in.
        /// </summary>
        /// <param name="message">The message being logged</param>
        /// <param name="level">The level of the message</param>
        void Log(string message, LogLevel level);
    }
}
