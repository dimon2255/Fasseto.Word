namespace Fasseto.Word.Core
{
    /// <summary>
    /// The Credentials for API model to update users profile details
    /// </summary>
    public class UpdateUserProfileApiModel
    {
        /// <summary>
        /// Users firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Users Lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Users Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Users Email
        /// </summary>
        public string Email { get; set; }
    }
}
