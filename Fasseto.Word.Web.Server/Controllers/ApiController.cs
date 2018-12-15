using Fasseto.Word.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
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

        /// <summary>
        /// Issues unique token for user
        /// </summary>
        /// <returns></returns>
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
            if (loginCredentials?.UsernameOrEmail == null || string.IsNullOrEmpty(loginCredentials?.UsernameOrEmail))
                return errorResponse;

            //Validate if the user credentials are correct
            var isEmail = loginCredentials.UsernameOrEmail.Contains("@");

            //Get User Details
            var user = isEmail ? await mUserManager.FindByEmailAsync(loginCredentials.UsernameOrEmail) 
                                 : 
                                 await mUserManager.FindByNameAsync(loginCredentials.UsernameOrEmail);

            //Fail to find a user, return error
            if(user == null)
                return errorResponse;

            //If we got here we have a user
            var isValidPassword = await mUserManager.CheckPasswordAsync(user, loginCredentials.Password);

            //password was wrong
            if (!isValidPassword)
                return errorResponse;

            //Get Username
            var username = user.UserName;

            //Set our tokens claims
            var claims = new[]
            {
                //Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                //The username using the Identity name so it fills out HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, username),
            };

            //Create the credentials used to generate tokens for user
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoC.Configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Generate the Jwt Token
            var token = new JwtSecurityToken(
                                        issuer: IoC.Configuration["Jwt:Issuer"],
                                        audience: IoC.Configuration["Jwt:Audience"],
                                        claims: claims,
                                        expires: DateTime.Now.AddMonths(3),
                                        signingCredentials: credentials
                                            );

            //Return token to the authenticated user
            return new ApiResponse<LoginResultApiModel>()
            {
                Response = new LoginResultApiModel()
                {
                    FirstName = user.Firstname,
                    Lastname = user.Lastname,
                    Email = user.Email,
                    Username = user.UserName,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                }
            };
       }
    }
}
