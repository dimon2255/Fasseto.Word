namespace Fasseto.Word.Core
{
    /// <summary>
    /// The details of email to send on behalf of the caller
    /// </summary>
    public class SendEmailDetails
    {
        /// <summary>
        /// Name of the sender
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// Email of the sender
        /// </summary>
        public string FromEmail { get; set; }

        /// <summary>
        /// Name of the receiver
        /// </summary>
        public string ToName { get; set; }

        /// <summary>
        /// Email of the Receiver
        /// </summary>
        public string ToEmail { get; set; }

        /// <summary>
        /// The email subject
        /// </summary>
        public string Subject{ get; set; }

        /// <summary>
        /// Email body content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Indicates if the body is HTML content
        /// </summary>
        public bool IsHtml { get; set; }
    }
}
