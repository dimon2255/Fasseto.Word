using Microsoft.AspNetCore.Identity;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// The user data and profile for our application
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// First name of the user
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string Lastname { get; set; }
    }
}
