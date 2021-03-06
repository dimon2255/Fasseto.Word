﻿namespace Fasseto.Word.Core
{
    /// <summary>
    /// The result of a successful login request via API call
    /// </summary>
    public class UserProfileDetailsApiModel
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
        public string LastName { get; set; }

        /// <summary>
        /// The users Username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Users email
        /// </summary>
        public string Email { get; set; }

        #endregion

        #region Public Helpers

        /// <summary>
        /// Converts <see cref="UpdateUserProfileApiModel"/> to <see cref="LoginCredentialsDataModel"/>
        /// </summary>
        /// <returns></returns>
        public LoginCredentialsDataModel ToLoginCredentialsDataModel()
        {
            return new LoginCredentialsDataModel()
            {
                Email = Email,
                Firstname = FirstName,
                Lastname = LastName,
                Username = UserName,
                Token = Token
            };
        }

        #endregion
    }
}
