namespace Fasseto.Word.Core
{
    /// <summary>
    /// The Credentials for an API client to register on the server 
    /// </summary>
    public class RegisterCredentialsApiModel
    {
        #region Public Properties

        /// <summary>
        /// Username for the user
        /// </summary>
        public string Username{ get; set; }

        /// <summary>
        /// Email for the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Firstname for the user
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Lastname for the user
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Password for the user
        /// </summary>
        public string Password { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RegisterCredentialsApiModel()
        {

        }

        #endregion
    }
}
