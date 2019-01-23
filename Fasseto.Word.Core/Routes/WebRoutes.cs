namespace Fasseto.Word.Core
{
    /// <summary>
    /// Relative Routes to all WEB NON-API calls to th server
    /// </summary>
    public static class WebRoutes
    {
        /// <summary>
        /// Route for creating the user
        /// </summary>
        public const string CreateUser = "user/create";

        /// <summary>
        /// Route for signing out the user
        /// </summary>
        public const string SignOutUser = "user/logout";

        /// <summary>
        /// Route to login in the user
        /// </summary>
        public const string LoginUser = "user/login";
    }
}