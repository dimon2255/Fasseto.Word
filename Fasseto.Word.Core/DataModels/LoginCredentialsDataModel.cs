namespace Fasseto.Word.Core
{
    /// <summary>
    /// User's Login Credentials for local Data Store
    /// </summary>
    public class LoginCredentialsDataModel
    {
        /// <summary>
        /// Unique Id 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///User's Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// User's Firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// User's Lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        public string Email{ get; set; }

        /// <summary>
        /// User's login Token
        /// </summary>
        public string Token { get; set; }
    }
}
