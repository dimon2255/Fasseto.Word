using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A service that handles sending emails
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// Sends an Email message with the given information
        /// </summary>
        /// <returns></returns>
        Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details);
    }
}
