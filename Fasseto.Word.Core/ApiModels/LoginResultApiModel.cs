namespace Fasseto.Word.Core
{
    /// <summary>
    /// The result of a successful login request via API call
    /// </summary>
    public class LoginResultApiModel
    {
        #region Public Properties

        /// <summary>
        /// The authentication token used to stay authenticated throughout future request
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The users last name
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// The users Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Users email
        /// </summary>
        public string Email { get; set; }

        #endregion
    }
}
