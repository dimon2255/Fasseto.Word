using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Dna
{
    /// <summary>
    /// Extension methods for the Dna framework
    /// </summary>
    public static class FrameworkExtensions
    {

        /// <summary>
        /// Injects all of the default services used by Dna.Framework
        /// </summary>
        /// <param name="construction">The construction</param>
        /// <returns></returns>
        public static FrameworkConstruction UseDefaultServices(this FrameworkConstruction construction)
        {
            //Add default exception handler
            construction.AddDefaultExceptionHandler();

            //Add default logger
            construction.AddDefaultLogger();

            return construction;
        }

        /// <summary>
        /// Injects the default loggers into the framework construction
        /// </summary>
        /// <param name="construction">The construction</param>
        /// <returns></returns>
        public static FrameworkConstruction AddDefaultLogger(this FrameworkConstruction construction)
        {
 
            //Add logging as default
            construction.Services.AddLogging(options =>
            {
                //Setup loggers from configuration
                options.AddConfiguration(construction.Configuration.GetSection("Logging"));

                //Add Loggers
                options.AddConsole();
                options.AddDebug();
            });

            //Add a default logger
            construction.Services.AddTransient(provider => provider.GetService<ILoggerFactory>().CreateLogger("Dna"));

            return construction;
        }

        /// <summary>
        /// Configures a framework construction <see cref="FrameworkConstruction"/>
        /// </summary>
        /// <param name="construction">The construction to configure</param>
        /// <param name="configure">The custom configuration action</param>
        /// <returns></returns>
        public static FrameworkConstruction Configure(this FrameworkConstruction construction, Action<IConfigurationBuilder> configure = null)
        {
            //Create our configuration sources
            var configurationBuilder = new ConfigurationBuilder()
                //Add Environment variables    
                .AddEnvironmentVariables()
                //Set base path for json files as startup location
                .SetBasePath(Directory.GetCurrentDirectory())
                // Add app settings json file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{construction.Configuration}.json", optional: true, reloadOnChange: true);


            //Let custom configuration
            configure?.Invoke(configurationBuilder);

            //Inject Configuration into services
            var configuration = configurationBuilder.Build();
            construction.Configuration = configuration;
            construction.Services.AddSingleton<IConfiguration>(configuration);

            return construction;
        }

        /// <summary>
        /// Adds a Default Exception Handler
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddDefaultExceptionHandler(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<IExceptionHandler>(new BaseExceptionHandler());

            return construction;
        }
    }
}
