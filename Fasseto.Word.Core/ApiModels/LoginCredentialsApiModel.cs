namespace Fasseto.Word.Core
{
    /// <summary>
    /// The Credentials for an API client to log in into server and receive token back.
    /// </summary>
    public class LoginCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// Username for the user
        /// </summary>
        public string UsernameOrEmail { get; set; }

        /// <summary>
        /// Password for the user
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public LoginCredentialsApiModel()
        {

        }

        #endregion
    }
}
