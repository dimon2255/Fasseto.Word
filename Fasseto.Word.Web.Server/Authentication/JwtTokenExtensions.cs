using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Extension methods for working with Jwt Tokens
    /// </summary>
    public static class JwtTokenExtensions
    {
        /// <summary>
        /// Generates Jwt bearer token containing the users name
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GenerateJwtToken(this ApplicationUser user)
        {
            //Set our tokens claims
            var claims = new[]
            {
                //Unique ID for this token
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),

                //The username using the Identity name so it fills out HttpContext.User.Identity.Name value
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
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

            //Write token as string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
