
using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    /// <summary>
    /// ViewModel Locator for ViewModels from the IoC for use in binding in XAML files
    /// </summary>
    public class ViewModelLocator
    {
        #region Public Properties

        /// <summary>
        /// Singleton instance of the locator
        /// </summary>
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();

        /// <summary>
        /// The actual application view model
        /// </summary>
        public static ApplicationViewModel ApplicationViewModel => ViewModelApplication;

        #endregion
    }
}

