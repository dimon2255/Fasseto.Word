namespace Fasseto.Word.Core
{
    /// <summary>
    /// Relative Routes to all WEB API calls to th server
    /// </summary>
    public static class ApiRoutes
    {
        /// <summary>
        /// Route for Registering a user
        /// </summary>
        public const string Register = "api/register";

        /// <summary>
        /// Route for verifying users email
        /// <remarks>
        ///  We'll be sending UserId and EmailToken as Get Parameters
        ///  i.e. -> /api/verify/email?userId=...&emailToken=...
        /// </remarks>
        /// </summary>
        public const string VerifyEmail = "api/verify/email";

        /// <summary>
        /// Route for Login in the user
        /// </summary>
        public const string Login = "api/login";
        
        /// <summary>
        /// Route for getting users profile 
        /// </summary>
        public const string GetUserProfile = "api/user/profile";

        /// <summary>
        /// Route for updating users profile
        /// </summary>
        public const string UpdateUserProfile = "api/user/profile/update";

        /// <summary>
        /// Route for updating users password
        /// </summary>
        public const string UpdateUserPassword = "api/user/password/update";
    }
}
