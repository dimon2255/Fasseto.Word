namespace Dna
{
    /// <summary>
    /// Constructs Framework with defaults
    /// </summary>
    public class DefaultFrameworkConstruction : FrameworkConstruction
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DefaultFrameworkConstruction()
        {
            this.Configure()
                .UseDefaultServices();
        }

        #endregion
    }
}
