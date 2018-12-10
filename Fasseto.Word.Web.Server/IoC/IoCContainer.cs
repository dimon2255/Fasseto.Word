using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fasseto.Word.Web.Server
{
    /// <summary>
    /// Shorthand access class to get the DI services with nice clean short code
    /// </summary>
    public static class IoC
    {
        public static ApplicationDBContext DBContext = null;

        static IoC()
        {
            DBContext = IoCContainer.Provider.GetService<ApplicationDBContext>();
        }
    }

    /// <summary>
    /// The dependency injection container making use of the built in .Net core service provider
    /// </summary>
    public static class IoCContainer
    {
        /// <summary>
        /// 
        /// </summary>
        public static IServiceProvider Provider{ get; set; }
    }
}
