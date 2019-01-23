using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Fasseto.Word.Core;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Handles sending templated emails
    /// </summary>
    public class EmailTemplateSender : IEmailTemplateSender
    {
        /// <summary>
        /// Sends an email with the given details using the general template
        /// </summary>
        /// <param name="details">The email message details. Note the content property is ignored</param>
        /// <param name="title">The title of the email</param>
        /// <param name="content1">The first line contents</param>
        /// <param name="content2">The second line contents</param>
        /// <param name="buttonText">The button text</param>
        /// <param name="buttonUrl">The button URL</param>
        /// <returns></returns>
        public async Task<SendEmailResponse> SendGeneralEmailAsync(SendEmailDetails details, string title, string content1, string content2, string buttonText, string buttonUrl)
        {

            var templateText = default(string);

            //Read the General Template from file
            //TODO: Replace with IOC flat data provider

            using(var reader = new StreamReader(Assembly.GetEntryAssembly().
                                                    GetManifestResourceStream("Fasseto.Word.Web.Server.Email.Templates.General.htm"), Encoding.UTF8))
            {
                templateText = await reader.ReadToEndAsync();
            }

            templateText = templateText.Replace("--Title--", title);
            templateText = templateText.Replace("--Content1--", content1);
            templateText = templateText.Replace("--Content2--", content2);
            templateText = templateText.Replace("--ButtonText--", buttonText);
            templateText = templateText.Replace("--ButtonUrl--", buttonUrl);

            details.Content = templateText;

            return await IoC.EmailSender.SendEmailAsync(details);
        }
    }
}
