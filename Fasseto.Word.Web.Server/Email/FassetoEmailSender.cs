using Fasseto.Word.Core;
using System.Threading.Tasks;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Handles sending emails specific to the Fasseto Word Server
    /// </summary>
    public static class FassetoEmailSender
    {
        public static async Task<SendEmailResponse> SendUserVerificationEmail(string displayName, string email, string verificationUrl)
        {
            return await IoC.EmailTemplateSender.SendGeneralEmailAsync(new SendEmailDetails()
            {
                IsHtml = true,
                FromEmail = IoC.Configuration["FassetoSettings:SendEmailFromEmail"],
                FromName = IoC.Configuration["FassetoSettings:SendEmailFromName"],
                ToEmail = email,
                ToName = displayName,
                Subject = "Verify You Email - Fasseto Word"
            },
                "Verify Email",
                $"Hi {displayName ?? "stranger"},",
                "Thanks for creating an account with us.<br/> To continue please verify your email with us.",
                "Verify Email",
                $"{verificationUrl}");
        }
    }
}
