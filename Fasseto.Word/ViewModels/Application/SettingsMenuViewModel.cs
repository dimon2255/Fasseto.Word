using Fasseto.Word.Core;
using System.Threading.Tasks;
using System.Windows.Input;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    public class SettingsMenuViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// User's Name
        /// </summary>
        public TextEntryViewModel Firstname { get; set; }

        /// <summary>
        /// User's Username
        /// </summary>
        public TextEntryViewModel Lastname{ get; set; }

        /// <summary>
        /// User's Password
        /// </summary>
        public PasswordEntryViewModel Password{ get; set; }

        /// <summary>
        /// User's Email
        /// </summary>
        public TextEntryViewModel Email { get; set; }

        /// <summary>
        /// Text for Logout Button
        /// </summary>
        public string LogoutButtonText { get; set; }
        
        #endregion

        #region Commands

        /// <summary>
        /// Command for the back button
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Logout Command
        /// </summary>
        public ICommand LogoutCommand { get; set; }

        /// <summary>
        /// Clears User's Data when he logs out
        /// </summary>
        public ICommand ClearUserDataCommand { get; set; }

        /// <summary>
        /// Loads the settings data from the client data store
        /// </summary>
        public ICommand LoadCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsMenuViewModel()
        {
            //Create commands
            CloseCommand = new RelayCommand(Close);
            LogoutCommand = new RelayCommand(Logout);
            ClearUserDataCommand = new RelayCommand(ClearUserData);
            LoadCommand = new RelayCommand(async() => await LoadAsync());
            


            LogoutButtonText = "Logout";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Loads User Data Store
        /// </summary>
        public async Task LoadAsync()
        {
            if (await ClientDataStore.HasCredentialsAsync())
            {
                var UserData = await ClientDataStore.GetLoginCredentialsAsync();

                ViewModelSettings.Firstname = new TextEntryViewModel()
                {
                    Label = "Name",
                    OriginalText = $"{UserData.Firstname} {UserData.Lastname}",
                };
                ViewModelSettings.Lastname = new TextEntryViewModel()
                {
                    Label = "Username",
                    OriginalText = $"{UserData.Username}",
                };
                ViewModelSettings.Password = new PasswordEntryViewModel()
                {
                    Label = "Password",
                    FakePassword = "*********",
                };
                ViewModelSettings.Email = new TextEntryViewModel()
                {
                    Label = "Email",
                    OriginalText = $"{UserData.Email}",
                };
            }
        }

        /// <summary>
        /// Executes when back command is fired
        /// </summary>
        private void Close()
        {
            //SEt the Settings menu visibility to false, which in turn hides the menu
            ViewModelApplication.SettingsMenuVisible = false;
        }

        /// <summary>
        /// Logs the user out
        /// </summary>
        private void Logout()
        {
            //TODO: Confirm that the user wants to logout


            //TODO: Clear any user/data cache
            ClearUserData();

            //Redirects the user to the login page
            ViewModelApplication.GoToPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Clears user's data
        /// </summary>
        public void ClearUserData()
        {
            //Clear all view models 
            Firstname = null;
            Lastname = null;
            Password = null;
            Email = null;
        }

        #endregion
    }
}
