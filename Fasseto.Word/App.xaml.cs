using Dna;
using Fasseto.Word.Core;
using Fasseto.Word.Relational;
using System.Threading.Tasks;
using System.Windows;

//Static using for easy access of DI Services
using static Fasseto.Word.DI;
using static Dna.Framework;

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

            //Load new Settings
            await ViewModelSettings.LoadAsync();
        }
    }
}
