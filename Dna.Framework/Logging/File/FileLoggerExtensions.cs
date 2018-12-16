using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Dna
{
    /// <summary>
    /// Extensions methods for the <see cref="FileLogger"/>
    /// </summary>
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// Adds a new file logger to a specific filepath for <see cref="FileLogger"/>
        /// </summary>
        /// <param name="builder">The log builder to add to</param>
        /// <param name="filepath">The path where to write to</param>
        /// <returns><see cref="ILoggingBuilder"/></returns>
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filepath, FileLoggerConfiguration configuration = null)
        {
            //Create a default configuration if not provided
            if (configuration == null)
                configuration = new FileLoggerConfiguration();

            //Add a file log provider to builder
            builder.AddProvider(new FileLoggerProvider(filepath , configuration));

            //Return the builder
            return builder;
        }

        /// <summary>
        /// Injects a new file logger to a specific logPath for <see cref="FileLogger"/>
        /// </summary>
        /// <param name="construction">The construction</param>
        /// <param name="logPath">The path where to write to</param>
        /// <returns><see cref="FrameworkConstruction"/></returns>
        public static FrameworkConstruction UseFileLogger(this FrameworkConstruction construction, string logPath = "log.txt")
        {
            construction.Services.AddLogging(options =>
            {
                options.AddFile(logPath);
            });

            return construction; 
        }
    }
}
