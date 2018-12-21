using Fasseto.Word.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Manages the WebAPI calls
    /// </summary>
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
        [Route("api/register")]
        public async Task<ApiResponse<RegisterResultApiModel>> RegisterAsync([FromBody] RegisterCredentialsApiModel registerCredentials)
        {
            var errorMessage = "Please provide all required details to register to an account";

            //Default Error Message
            var errorResponse = new ApiResponse<RegisterResultApiModel>()
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
            var result =  await mUserManager.CreateAsync(user, registerCredentials?.Password);

            if (result.Succeeded)
            {
                //Find newly created user, to send to the client DataStore
                var UserIdentity = await mUserManager.FindByNameAsync(registerCredentials.Username);

                //Generate Email verification code
                var emailVerifictionCode = await mUserManager.GenerateEmailConfirmationTokenAsync(user);

                //TODO: Email the user verification code

                //Return valid response
                return new ApiResponse<RegisterResultApiModel>()
                {
                    Response = new RegisterResultApiModel()
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
                return new ApiResponse<RegisterResultApiModel>()
                {
                    //Aggregate all errors into a single error string
                    ErrorMessage = result.Errors.ToList()
                             .Select(f => f.Description)
                             .Aggregate((a, b) => $"{a}{Environment.NewLine}{b}")
                };
            }
        }

        /// <summary>
        /// Logs the user in and Issues unique token for user to use for subsequent requests
        /// </summary>
        /// <returns>ApiResponse of LoginResultApiModel</returns>
        [Route("api/login")]
        public async Task<ApiResponse<LoginResultApiModel>> LogInAsync([FromBody]LoginCredentialsApiModel loginCredentials)
        {
            //TODO: Localize all strings
            var errorMessage = "Invalid username or password";

            //Error Response
            var errorResponse = new ApiResponse<LoginResultApiModel>()
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
            return new ApiResponse<LoginResultApiModel>()
            {
                Response = new LoginResultApiModel()
                {
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Email = user.Email,
                    UserName = user.UserName,
                    Token = user.GenerateJwtToken()
                }
            };
        }

        #endregion


    }
}
