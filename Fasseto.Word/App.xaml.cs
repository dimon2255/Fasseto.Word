using Dna;
using Fasseto.Word.Core;
using Fasseto.Word.Relational;
using System.Threading.Tasks;
using System.Windows;

//Static using for easy access of DI Services
using static Fasseto.Word.DI;
using static Dna.Framework;
using System;
using Dna.Web;

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
            Logger.LogDebugSource("Application starting...");

            ViewModelApplication.GoToPage(
                await ClientDataStore.HasCredentialsAsync() ?
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
            Construct<DefaultFrameworkConstruction>()
                    .AddFileLogger()
                    .AddClientDataStore()
                    .AddFassetoWordViewModels()
                    .AddFassetoClientServices()
                    .Build();

            //Register a service
            await ClientDataStore.EnsureDataStoreAsync();

            //Monitor for server connection status
            MonitorServerStatus();

            //Load new Settings, only if server is reachable
            if (ViewModelApplication.ServerReachable)
            {
                CoreDI.TaskManager.RunAndForget(ViewModelSettings.LoadAsync);
            }
        }

        /// <summary>
        /// Monitors if the server is up, so we can connect to it
        /// </summary>
        private void MonitorServerStatus()
        {
            //Create and endpoint checker 
            var httpWatcher = new HttpEndPointChecker(
                Configuration["FassetoWordServer:HostUrl"],
                interval: 1000,
                logger: Logger,
                stateChangedCallback: (result) =>
                {
                    // Update the view model property with the new result
                    ViewModelApplication.ServerReachable = result;
                });
        }
    }
}
