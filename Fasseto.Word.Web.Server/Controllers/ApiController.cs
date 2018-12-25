using Fasseto.Word.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Manages the WebAPI calls
    /// </summary>
  //  [AuthorizeToken]
    public class ApiController : Controller
    {
        #region Private Properties

        /// <summary>
        /// Scoped application context
        /// </summary>
        protected ApplicationDBContext mDbcontext;

        /// <summary>
        /// The Manager for handling users, creation, deletion, roles, searching...
        /// </summary>
        protected UserManager<ApplicationUser> mUserManager;

        /// <summary>
        /// The manager for handling signing in and out of users
        /// </summary>
        protected SignInManager<ApplicationUser> mSignInManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="context">Database Context Connection</param>
        /// <param name="userManager">Manager for users</param>
        /// <param name="signInManager">Manager for signing in/out of users</param>
        public ApiController(ApplicationDBContext context,
                              UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager)
        {
            mDbcontext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion


        #region API Actions

        /// <summary>
        /// Tries to register a new account on the server
        /// </summary>
        /// <param name="registerCredentails">The registration details</param>
        /// <returns>Returns the result of the register request</returns>
//        [AllowAnonymous]
        [Route("api/register")]
        public async Task<ApiResponse<UserProfileDetailsApiModel>> RegisterAsync([FromBody] RegisterCredentialsApiModel registerCredentials)
        {
            var errorMessage = "Please provide all required details to register to an account";

            //Default Error Message
            var errorResponse = new ApiResponse<UserProfileDetailsApiModel>()
            {
                //Set error message
                ErrorMessage = errorMessage
            };

            //If no credentials provided, respond with error message
            if (registerCredentials == null)
                return errorResponse;

            //Make sure we have a username, before proceeding
            if (string.IsNullOrEmpty(registerCredentials?.Username))
                return errorResponse;


            var user = new ApplicationUser()
            {
                UserName = registerCredentials?.Username,
                Firstname = registerCredentials?.Firstname,
                Lastname = registerCredentials?.Lastname,
                Email = registerCredentials?.Email
            };

            //Try to create user
            var result = await mUserManager.CreateAsync(user, registerCredentials?.Password);

            if (result.Succeeded)
            {
                //Find newly created user, to send to the client DataStore
                var UserIdentity = await mUserManager.FindByNameAsync(registerCredentials.Username);

                //Generate Email verification code
                var emailVerifictionCode = await mUserManager.GenerateEmailConfirmationTokenAsync(user);

                //Email the user verification code
                var confirmationUrl = $"http://{Request.Host.Value}/api/verify/email/{HttpUtility.UrlEncode(UserIdentity.Id)}/{HttpUtility.UrlEncode(emailVerifictionCode)}";

                //Send verification email.
                await FassetoEmailSender.SendUserVerificationEmail(UserIdentity.UserName, UserIdentity.Email, confirmationUrl);

                //Return valid response
                return new ApiResponse<UserProfileDetailsApiModel>()
                {
                    Response = new UserProfileDetailsApiModel()
                    {
                        FirstName = UserIdentity.Firstname,
                        LastName = UserIdentity.Lastname,
                        Email = UserIdentity.Email,
                        UserName = UserIdentity.UserName,

                        Token = user.GenerateJwtToken()
                    }
                };
            }
            else
            {
                return new ApiResponse<UserProfileDetailsApiModel>()
                {
                    //Aggregate all errors into a single error string
                    ErrorMessage = result.Errors.AggregateErrors()
                };
            }
        }


        /// <summary>
        /// Validates the email using token and userId provided in Url
        /// </summary>
        /// <returns></returns>
        [Route("api/verify/email/{userId}/{emailToken}")]
        [HttpGet]
        public async Task<IActionResult> VerifyEmailAsync(string userId, string emailToken)
        {
             //Get the User
            var user = await mUserManager.FindByIdAsync(userId);

            //NOTE: Issue at the minute with URL Decoding that contains /'s does not replace them
            //          https://github.com/aspnet/AspNetCore/issues/2669
            //
            // For now manually fix that

            emailToken = emailToken.Replace("%2f", "/").Replace("%2F", "/");

            //if the user is null
            if (user == null)
                return Content("User not found");

            //If we have the user
            var result = await mUserManager.ConfirmEmailAsync(user, emailToken);

            if (result.Succeeded)
            {
                return Content("Email Verified");
            }

            return Content("Invalid Token");
        }

        /// <summary>
        /// Logs the user in and Issues unique token for user to use for subsequent requests
        /// </summary>
        /// <returns>ApiResponse of LoginResultApiModel</returns>
//        [AllowAnonymous]
        [Route("api/login")]
        public async Task<ApiResponse<UserProfileDetailsApiModel>> LogInAsync([FromBody]LoginCredentialsApiModel loginCredentials)
        {
            //TODO: Localize all strings
            var errorMessage = "Invalid username or password";

            //Error Response
            var errorResponse = new ApiResponse<UserProfileDetailsApiModel>()
            {
                //Set error message
                ErrorMessage = errorMessage
            };

            //Make sure we have a username
            if (string.IsNullOrEmpty(loginCredentials?.UsernameOrEmail))
                return errorResponse;

            //Validate if the user credentials are correct
            var isEmail = loginCredentials.UsernameOrEmail.Contains("@");

            //Get User Details
            var user = isEmail ? await mUserManager.FindByEmailAsync(loginCredentials.UsernameOrEmail)
                                 :
                                 await mUserManager.FindByNameAsync(loginCredentials.UsernameOrEmail);

            //Fail to find a user, return error
            if (user == null)
                return errorResponse;

            //If we got here we have a user
            var isValidPassword = await mUserManager.CheckPasswordAsync(user, loginCredentials.Password);

            //password was wrong
            if (!isValidPassword)
                return errorResponse;

            //Get Username
            var username = user.UserName;

            //Return token to the authenticated user
            return new ApiResponse<UserProfileDetailsApiModel>()
            {
                Response = new UserProfileDetailsApiModel()
                {
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = user.GenerateJwtToken()
                }
            };
        }

        /// <summary>
        /// Returns the users profile details based on the authenticated user
        /// </summary>
        /// <returns></returns>
        [Route("api/user/profile")]
        public async Task<ApiResponse<UserProfileDetailsApiModel>> GetUserProfileAsync()
        {
            //Get user claims
            var user = await mUserManager.GetUserAsync(HttpContext.User);

            if (user == null)
                return new ApiResponse<UserProfileDetailsApiModel>()
                {
                    ErrorMessage = "User not found"
                };

            //Return token to the authenticated user
            return new ApiResponse<UserProfileDetailsApiModel>()
            {
                Response = new UserProfileDetailsApiModel()
                {
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = user.GenerateJwtToken()
                }
            };
        }

        /// <summary>
        /// Returns successful response if the update was successful,
        /// otherwise returns the errors
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ApiResponse> UpdateUserProfileAsync([FromBody] UpdateUserProfileApiModel model)
        {
            #region Declare Variable

            //Create an empty list for errors
            var errors = new List<string>();

            // Flag to signal if email has changed
            var emailChanged = false;

            #endregion

            #region Get User

            //Make the List of empty errors
            var user = await  mUserManager.GetUserAsync(HttpContext.User);

            if (user == null)
                return new ApiResponse<UserProfileDetailsApiModel>()
                {
                    ErrorMessage = "User not found"
                };

            #endregion

            #region Update User Profile

            //Update User Details
            if (model.Firstname != null)
                user.Firstname = model.Firstname;

            if (model.Lastname != null)
                user.Lastname = model.Lastname;

            if (model.Username != null)
                user.UserName = model.Username;

            if (model.Email != null &&
                !string.Equals(model.Email.Replace(" ",""), user.NormalizedEmail))
            {
                //Update the email
                user.Email = model.Email;

                //Un-verify the email
                user.EmailConfirmed = false;

                emailChanged = true;
            }

            #endregion

            #region Save Profile

            //Attempts to commit changes to data store
            var result = await mUserManager.UpdateAsync(user);

            //TODO: Email Sender

            #endregion

            #region Response

            if (result.Succeeded)
                return new ApiResponse();
            else
            {
                return new ApiResponse()
                {
                    ErrorMessage = result.Errors.AggregateErrors()
                };
            }

            #endregion

        }

        #endregion
    }
}
