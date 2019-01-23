using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dna
{
    /// <summary>
    /// The Construction Information when staring up and configuring Dna.Framework
    /// </summary>
    public class FrameworkConstruction
    {
        #region Public Properties

        /// <summary>
        /// The services that will get used and compiled once the framework is built
        /// </summary>
        public IServiceCollection Services { get; set; }

        /// <summary>
        /// The Environment for Dna.Framework
        /// </summary>
        public FrameworkEnvironment Environment{ get; set; }

        /// <summary>
        /// The Configuration to use for Dna.Framework
        /// </summary>
        public IConfiguration Configuration { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FrameworkConstruction()
        {
            //Create Services Collection
            Services = new ServiceCollection();

            //Create environment details
            Environment = new FrameworkEnvironment();

            //Inject Environment into Services
            Services.AddSingleton(Environment);
        }

        #endregion

    }
}
