using Fasseto.Word.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Extension methods for any SendGrid classes
    /// </summary>
    public static class SendGridExtensions
    {
        /// <summary>
        /// Injects the <see cref="SendGridEmailSender"/> into services to handle the 
        /// <see cref="IEmailSender"/> service
        /// </summary>
        /// <param name="services">Services Collection to add a service to</param>
        /// <returns></returns>
        public static IServiceCollection AddSendGridEmailSender(this IServiceCollection services)
        {
            //Inject the SendGrid email sender
            services.AddTransient<IEmailSender, SendGridEmailSender>();

            return services;
        }
    }
}
