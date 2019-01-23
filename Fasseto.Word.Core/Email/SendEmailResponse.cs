using System.Collections.Generic;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A response from a SendEmail call for any <see cref="IEmailSender"/> implementation
    /// </summary>
    public class SendEmailResponse
    {
        /// <summary>
        /// True if the email was sent successfully
        /// </summary>
        public bool Successful => !(Errors?.Count > 0);

        /// <summary>
        /// Error message on Email sending failure
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
