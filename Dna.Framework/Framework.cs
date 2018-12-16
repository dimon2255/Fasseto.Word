using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Dna
{
    /// <summary>
    /// Main entry point into the Dna Framework library
    /// </summary>
    public static class Framework
    { 
        #region Public Properties

        /// <summary>
        /// Provides DI Service Provider
        /// </summary>
        public static IServiceProvider Provider { get; private set; }

        /// <summary>
        /// Gets the default logger for the framework
        /// </summary>
        public static ILogger Logger => Provider.GetService<ILogger>();

        /// <summary>
        /// Gets the Configuration for the Framework environment
        /// </summary>
        public static IConfiguration Configuration => Provider.GetService<IConfiguration>();
        
        /// <summary>
        /// Gets the Framework Environment service
        /// </summary>
        public static FrameworkEnvironment Environment => Provider.GetService<FrameworkEnvironment>();

        #endregion

        #region Public Methods
            
        /// <summary>
        /// Should be called at the very start of your application to configure and setup
        /// the Dna Framework
        /// </summary>
        /// <param name="configure">Action that adds custom configuration <see cref="IConfigurationBuilder"/> and adds configuration to it </param>
        /// <param name="injection">Action to inject services into ServicesCollection</param>
        public static void Startup(Action<IConfigurationBuilder> configure = null, Action<IServiceCollection, IConfiguration> injection = null)
        {
            #region Initialize

            //Create a new list of dependencies
            var services = new ServiceCollection();

            #endregion

            #region Environment

            //Create environment details
            var environment = new FrameworkEnvironment();

            //Inject Environment Services
            services.AddSingleton(environment);

            #endregion

            #region Configuration

            //Create our configuration sources
            var configurationBuilder = new ConfigurationBuilder()
                //Add Environment variables    
                .AddEnvironmentVariables()
                //Set base path for json files as startup location
                .SetBasePath(Directory.GetCurrentDirectory())
                // Add app settings json file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.Configuration}.json", optional: true, reloadOnChange: true);


            //Let custom configuration
            configure?.Invoke(configurationBuilder);

            //Inject Configuration into services
            var configuration = configurationBuilder.Build();
            services.AddSingleton<IConfiguration>(configuration);

            #endregion

            #region Logging

            //Add logging as default
            services.AddLogging(options =>
            {
                //Setup loggers from configuration
                options.AddConfiguration(configuration.GetSection("Logging"));

                //Add Loggers
                options.AddConsole();
                options.AddDebug();

                // Add a file logger
                options.AddFile("log.txt");

            });

            //Add default logger
            services.AddDefaultLogger();

            #endregion

            #region Custom Services and Building

            //Allow Custom Service Injection
            injection?.Invoke(services, configuration);

            //Build the service provider
            Provider = services.BuildServiceProvider(); 
            
            #endregion

            //Log startup complete
            Logger.LogCriticalSource($"Dna Framework started in {environment.Configuration} mode...");
        }

        #endregion
    }
}
