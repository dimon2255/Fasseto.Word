using Fasseto.Word.Core;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Sends emails using SendGrid email service
    /// </summary>
    public class SendGridEmailSender : IEmailSender
    {

        public async Task<SendEmailResponse> SendEmailAsync(SendEmailDetails details)
        {
            //Get the SendGrid Key
            var apikey = IoC.Configuration["SendGridKey"];

            //Create a new SendGrid client
            var client = new SendGridClient(apikey);

            //From
            var from = new EmailAddress(details.FromEmail, details.FromName);

            //To
            var to = new EmailAddress(details.ToEmail, details.ToName);

            //Email Subject
            var subject = details.Subject;

            //Content
            var content = details.Content;

            //Create Email class
            var msg = MailHelper.CreateSingleEmail(
                from,
                to,
                //Plain Content
                subject, details.IsHtml ? null : details.Content,
                //HTML Content
                details.IsHtml ? details.Content : null);

            //Send Email
            var response = await client.SendEmailAsync(msg);

            //If, Successful
            if (response.StatusCode == HttpStatusCode.Accepted)
                return new SendEmailResponse();


            try
            {
                //Read the response body
                var bodyResult = await response.Body.ReadAsStringAsync();

                //Deserialize the response
                var sendGridResponse = JsonConvert.DeserializeObject<SendGridResponse>(bodyResult);

                //add any errors to response
                var errorResponse = new SendEmailResponse()
                {
                    Errors = sendGridResponse?.Errors.Select(f => f.Message).ToList()
                };

                if (errorResponse.Errors == null || errorResponse.Errors.Count == 0)
                    errorResponse.Errors = new List<string>(new[] { "Unknown error from email sending service, please contact Fasseto support"});

                //Return the response
                return errorResponse;
            }
            catch (Exception ex)
            {
                //TODO: Localization
                if (Debugger.IsAttached)
                {
                    var error = ex;
                    Debugger.Break();
                }

                return new SendEmailResponse()
                {
                    Errors = new List<string>(new[] { "Unknown error occurred" })
                };
            }
        }
    }
}
