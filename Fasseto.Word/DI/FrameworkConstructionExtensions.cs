using Dna;
using Fasseto.Word.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Fasseto.Word
{
    /// <summary>
    /// Extension methods for <see cref="FrameworkConstruction"/> class
    /// Used to add service to DI container
    /// </summary>
    public static class FrameworkConstructionExtensions
    {
        /// <summary>
        /// Injects the ViewModels needed for Fasseto.Word
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddFassetoWordViewModels(this FrameworkConstruction construction)
        {
            //Bind Application ViewModels
            construction.Services.AddSingleton<ApplicationViewModel>();
            construction.Services.AddSingleton<SettingsMenuViewModel>();

            return construction;
        }


        /// <summary>
        /// Injects client services into the application
        /// </summary>
        /// <param name="construction"></param>
        /// <returns></returns>
        public static FrameworkConstruction AddFassetoClientServices(this FrameworkConstruction construction)
        {
            //Bind client services
            construction.Services.AddTransient<ITaskManager, BaseTaskManager>();
            construction.Services.AddTransient<IFileManager, BaseFileManager>();
            construction.Services.AddTransient<IUIManager, UIManager>();

            return construction;
        }
    }
}

