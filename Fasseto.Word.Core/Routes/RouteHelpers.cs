using static Dna.Framework;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Helper methods for Routes
    /// </summary>
    public static class RouteHelpers
    {
        /// <summary>
        /// Converts a relative URL to absolute URL
        /// <paramref name="relativeUrl"/> relative URL 
        /// </summary>
        /// <returns>Absolute URL including the HOST URL</returns>
        public static string GetAbsoluteRoute(string relativeUrl)
        {
            //get the host
            var host = Configuration["FassetoWordServer:HostUrl"];

            if (string.IsNullOrEmpty(relativeUrl))
                return host;

            if (!(relativeUrl.StartsWith("/")))
            {
                relativeUrl = $"/{relativeUrl}";
            }

            return host + relativeUrl;
        }
    }
}
