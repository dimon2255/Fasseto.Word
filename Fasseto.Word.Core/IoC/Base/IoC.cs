using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    public static class IoC
    {
        #region Public Properties

        /// <summary>
        /// The Kernel for our IoC Container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// Get the UI Manager for users
        /// </summary>
        public static IUIManager UI => IoC.Get<IUIManager>();

        /// <summary>
        /// Get the UI Manager for users
        /// </summary>
        public static ApplicationViewModel Application => IoC.Get<ApplicationViewModel>();

        /// <summary>
        /// Get the <see cref="IUIManager"/> for users
        /// </summary>
        public static SettingsMenuViewModel Settings => IoC.Get<SettingsMenuViewModel>();

        /// <summary>
        /// Get the <see cref="IFileManager"/> for writing to files 
        /// </summary>
        public static IFileManager File => IoC.Get<IFileManager>();

        /// <summary>
        /// Get the <see cref="ILogFactory"/> for logging
        /// </summary>
        public static ILogFactory Logger => IoC.Get<ILogFactory>();

        /// <summary>
        /// Get the <see cref="ITaskManager"/> for Task ops
        /// </summary>
        public static ITaskManager Task => IoC.Get<ITaskManager>();


        #endregion

        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// NOTE: Must called as your application starts up to ensure all
        ///         services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view models
            BindViewModels();

        }

        /// <summary>
        /// Binds all Singleton View Models
        /// </summary>
        private static void BindViewModels()
        {
            //Binds ViewModels with IOC Container
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
            Kernel.Bind<SettingsMenuViewModel>().ToConstant(new SettingsMenuViewModel());
        }

        #endregion

        /// <summary>
        /// Gets the service from the IoC, of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }

    }
}
