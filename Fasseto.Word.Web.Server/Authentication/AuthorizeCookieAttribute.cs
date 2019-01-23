using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// The authorization policy for cookie-based authentication
    /// </summary>
    public class AuthorizeCookieAttribute : AuthorizeAttribute
    {
        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AuthorizeCookieAttribute()
        {
            // Add the Cookie authentication scheme
            AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme; 
        }

        #endregion
    }
}
