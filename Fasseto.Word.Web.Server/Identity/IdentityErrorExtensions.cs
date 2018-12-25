using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Extension methods for Identity
    /// </summary>
    public static class IdentityErrorExtensions
    {
        /// <summary>
        /// Combines all errors into a single string 
        /// with each error separated by a new line
        /// </summary>
        /// <param name="errors"></param>
        public static string AggregateErrors(this IEnumerable<IdentityError> errors)
        {
            return errors?.ToList()
                            .Select(f => f.Description)
                            .Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");

        }
    }
}
