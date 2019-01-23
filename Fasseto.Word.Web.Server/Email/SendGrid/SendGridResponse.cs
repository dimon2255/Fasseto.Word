using System.Collections.Generic;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Response to a SendGrid SendMessage call
    /// </summary>
    public class SendGridResponse
    {
        /// <summary>
        /// List of errors from response
        /// </summary>
        public List<SendGridResponseError> Errors { get; set; }
    }
}
