using Dna;
using Fasseto.Word.Core;
using System.Threading.Tasks;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    /// <summary>
    /// Extension methods for the <see cref="WebRequestResult"/> class
    /// </summary>
    public static class WebRequestsResultExtensions
    {
        /// <summary>
        /// Checks the WebRequestResult for any errors, displaying the if there any
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response to check</param>
        /// <param name="title">Title of the dialog, if any errors are found</param>
        /// <returns>True if there are errors, and false if none</returns>
        public static async Task<bool> DisplayErrorOnFailureAsync<T>(this WebRequestResult<ApiResponse<T>> response, string title)
        {

            //If there was no response, bad data, or a response with a failed error message
            if (response == null || response.ServerResponse == null || !response.ServerResponse.Successful)
            {
                //TODO: Localize Strings
                var message = "Unknown error from server call";

                if (response?.ServerResponse != null)
                {
                    message = response.ServerResponse.ErrorMessage;
                }
                else if (string.IsNullOrWhiteSpace(response?.RawServerResponse))
                {
                    message = $"Unexpected response from server. {response.RawServerResponse}";
                }
                else if (response != null)
                {
                    message = $"Failed to communicate with server. Status code {response.StatusCode}. {response.StatusDescription}";
                }


                await UI.ShowMessage(new MessageBoxDialogViewModel()
                {
                    //TODO: LOcalize Strings
                    Title = title,
                    Message = message
                });

               
                return true;
            }

            //no error
            return false;
        }
    }
}
