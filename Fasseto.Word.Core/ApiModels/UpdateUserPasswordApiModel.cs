namespace Fasseto.Word.Core
{
    /// <summary>
    /// The Credentials for API model to update users password
    /// </summary>
    public class UpdateUserPasswordApiModel
    {
        #region Public Properties

        /// <summary>
        /// The current password of the user
        /// </summary>
        public string CurrentPassword { get; set; }

        /// <summary>
        /// New password of the user
        /// </summary>
        public string NewPassword { get; set; }

        #endregion
    }
}
