namespace Dna
{
    /// <summary>
    /// Details about the current system environment
    /// </summary>
    public class FrameworkEnvironment
    {
        #region Public Properties

        /// <summary>
        /// True if we are in a development mode
        /// </summary>
        public bool IsDevelopment { get; set; } = true;

        /// <summary>
        /// The configuration of the environment -> Either Development or Production
        /// </summary>
        public string Configuration => IsDevelopment ? "Development" : "Production";

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public FrameworkEnvironment()
        {
    #if RELEASE
                IsDevelopment = false;
    #endif
        }

        #endregion
    }
}
