using Dna;
using Fasseto.Word.Core;
using System;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup, we load our IoC container immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Set up all application components
            ApplicationSetup();

            //Log it
            IoC.Logger.Log("Application starting...", LogLevel.Debug);
            object 

            //Show the main window
            Current.MainWindow = new Dialog();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Sets up all Application Components
        /// </summary>
        private void ApplicationSetup()
        {
            //Setup Dna Framework
            new DefaultFrameworkConstruction()
                .UseFileLogger()
                .Build();

            // Setup IoC
            IoC.Setup();

            //Bind a TaskManager
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            //Bind a FileManager
            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            //Bind a UIManager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

        }
    }
}
