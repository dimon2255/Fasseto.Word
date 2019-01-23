using Fasseto.Word.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Fasseto.Word.Web.Server
{ 
   /// <summary>
   /// A shorthand access class to get DI services with nice clean short code
   /// </summary>
    public static class IoC
    {
        /// <summary>
        /// The service provider for this application
        /// </summary>
        private static IServiceProvider mProvider;

        /// <summary>
        /// Initializes Service Provider
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Init(IServiceProvider serviceProvider)
        {
            mProvider = serviceProvider;
        }

        /// <summary>
        /// The configuration manager for the application
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// The scoped instance of the <see cref="ApplicationDbContext"/>
        /// </summary>
        public static ApplicationDBContext ApplicationDbContext => mProvider.GetService<ApplicationDBContext>();

        /// <summary>
        /// The transient instance of the <see cref="IEmailSender"/>
        /// </summary>
        public static IEmailSender EmailSender => mProvider.GetService<IEmailSender>();

        /// <summary>
        /// The transient instance of the <see cref="IEmailTemplateSender"/>
        /// </summary>
        public static IEmailTemplateSender EmailTemplateSender => mProvider.GetService<IEmailTemplateSender>();


    }
}
