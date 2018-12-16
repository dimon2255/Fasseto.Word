﻿using Microsoft.Extensions.Configuration;
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

        /// <summary>
        /// Gets the Exception Handler service
        /// </summary>
        public static IExceptionHandler ExceptionHandler => Provider.GetService<IExceptionHandler>();

        #endregion

        #region Public Methods

        public static void Test()
        {
            new DefaultFrameworkConstruction()
                .UseFileLogger()
                .Build();
        }

        /// <summary>
        /// Should be called once a framework construction is finished and we want
        /// to build it
        /// </summary>
        /// <param name="construction"></param>
        public static void Build(this FrameworkConstruction construction)
        {
             Provider = construction.Services.BuildServiceProvider(); 

            //Log startup complete
            Logger.LogCriticalSource($"Dna Framework started in {Environment.Configuration} mode...");
        }

        #endregion
    }
}
