using Dna;
using Fasseto.Word.Core;
using Fasseto.Word.Relational;
using System;
using System.Threading.Tasks;
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
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //Set up all application components
            await ApplicationSetupAsync();

            //Log it
            IoC.Logger.Log("Application starting...", LogLevel.Debug);

            IoC.Application.GoToPage(
                await IoC.ClientDataStore.HasCredentialsAsync() ?
                    ApplicationPage.Chat :
                    ApplicationPage.Login);

            //Show the main window
            Current.MainWindow = new Dialog();
            Current.MainWindow.Show();
        }

        /// <summary>
        /// Sets up all Application Components
        /// </summary>
        private async Task ApplicationSetupAsync()
        {
            //Setup Dna Framework
            new DefaultFrameworkConstruction()
                .UseClientDataStore()
                .UseFileLogger()
                .Build();


            // Setup IoC
            IoC.Setup();

            //Bind a logger
            IoC.Kernel.Bind<ILogFactory>().ToConstant(new BaseLogFactory(new[]
            {
                //TODO: Add AppicationSettings so we can set/edit a log location
                //      for now just log to the path where this application is running
                 new Core.FileLogger("OldLog.txt")
            }));

            //Bind a TaskManager
            IoC.Kernel.Bind<ITaskManager>().ToConstant(new TaskManager());

            //Bind a FileManager
            IoC.Kernel.Bind<IFileManager>().ToConstant(new FileManager());

            //Bind a UIManager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());

            //Register a service
            await IoC.ClientDataStore.EnsureDataStoreAsync();

            //Load new Settings
            await IoC.Settings.LoadAsync();
        }
    }
}
