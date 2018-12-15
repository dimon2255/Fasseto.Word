using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Shorthand access class to get the DI services with nice clean short code
    /// </summary>
    public static class IoC
    {
        /// <summary>
        /// Service Provider for DI
        /// </summary>
        public static IServiceProvider Provider { get; set; }

        /// <summary>
        /// Configuration Service Provider
        /// </summary>
        public static IConfiguration Configuration { get; set; }
    }

}
