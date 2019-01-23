using Dna;
using Fasseto.Word.Core;

namespace Fasseto.Word
{
    /// <summary>
    ///Shorthand access class to get DI services with nice clean short code...
    /// </summary>
    public static class DI
    {
        /// <summary>
        /// Get the UI Manager for users
        /// </summary>
        public static IUIManager UI => Framework.Service<IUIManager>();

        /// <summary>
        /// Get the UI Manager for users
        /// </summary>
        public static ApplicationViewModel ViewModelApplication => Framework.Service<ApplicationViewModel>();

        /// <summary>
        /// Get the <see cref="IUIManager"/> for users
        /// </summary>
        public static SettingsMenuViewModel ViewModelSettings => Framework.Service<SettingsMenuViewModel>();

        /// <summary>
        /// Get the <see cref="IClientDataStore"/> for Task ops
        /// </summary>
        public static IClientDataStore ClientDataStore => Framework.Service<IClientDataStore>();
    }
}
