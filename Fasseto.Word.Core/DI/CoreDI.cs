using Dna;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Core DI services 
    /// </summary>
    public static class CoreDI
    {
        #region Public Properties

        /// <summary>
        /// Get the <see cref="IFileManager"/> for writing to files 
        /// </summary>
        public static IFileManager FileManager => Framework.Service<IFileManager>();

        /// <summary>
        /// Get the <see cref="ITaskManager"/> for Task ops
        /// </summary>
        public static ITaskManager TaskManager => Framework.Service<ITaskManager>();

        #endregion
    }
}
