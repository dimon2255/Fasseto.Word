using Dna;
using Fasseto.Word.Core;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    public class SettingsMenuViewModel : BaseViewModel
    {

        #region Public Properties

        /// <summary>
        /// User's Firstname
        /// </summary>
        public TextEntryViewModel Firstname { get; set; }

        /// <summary>
        /// User's Lastname
        /// </summary>
        public TextEntryViewModel Lastname { get; set; }

        /// <summary>
        /// User's Username
        /// </summary>
        public TextEntryViewModel Username { get; set; }

        /// <summary>
        /// User's Password
        /// </summary>
        public PasswordEntryViewModel Password { get; set; }

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

        /// <summary>
        /// Save the first name to the server
        /// </summary>
        public ICommand SaveFirstNameCommand { get; set; }

        /// <summary>
        /// Save the last name to the server
        /// </summary>
        public ICommand SaveLastNameCommand { get; set; }

        /// <summary>
        /// Save the Username to the server
        /// </summary>
        public ICommand SaveUsernameCommand { get; set; }

        /// <summary>
        /// Save the Email to the server
        /// </summary>
        public ICommand SaveEmailCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsMenuViewModel()
        {
            //Create commands
            CloseCommand = new RelayCommand(Close);
            LogoutCommand = new RelayCommand(async () => await LogoutAsync());
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            //Async command Actions
            LoadCommand = new RelayCommand(async () => await LoadAsync());
            SaveFirstNameCommand = new RelayCommand(async () => await SaveFirstNameAsync());
            SaveLastNameCommand = new RelayCommand(async () => await SaveLastNameAsync());
            SaveUsernameCommand = new RelayCommand(async () => await SaveUserNameAsync());
            SaveEmailCommand = new RelayCommand(async () => await SaveEmailAsync());

            CreateUI();
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Executes when back command is fired
        /// </summary>
        private void Close()
        {
            //Set the Settings menu visibility to false, which in turn hides the menu
            ViewModelApplication.SettingsMenuVisible = false;
        }

        /// <summary>
        /// Logs the user out
        /// </summary>
        private async Task LogoutAsync()
        {
            //TODO: Confirm that the user wants to logout

            await ClientDataStore.ClearAllLoginCredentialsAsync();

            //Clean all application level data
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
            Username = null;
            Password = null;
            Email = null;
        }

        /// <summary>
        /// Loads User Data Store
        /// </summary>
        public async Task LoadAsync()
        {
            await UpdateValuesFromLocalStoreAsync();

            //TODO: Load user profile details from server

            //var result = await WebRequests.PostAsync<ApiResponse<UserProfileDetailsApiModel>>(
            //                                                        "http://localhost:5000/api/login",
            //                                                         new LoginCredentialsApiModel()
            //                                                         {
            //                                                             UsernameOrEmail = Email,
            //                                                             Password = (parameter as IHavePassword).SecurePassword.Unsecure()
            //                                                         }

            //    );
        }



        /// <summary>
        /// Save the new FirstName to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SaveFirstNameAsync()
        {
            //TODO: Update server
            await Task.Delay(3000);


            return true;
        }

        /// <summary>
        /// Save the new LastName to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SaveLastNameAsync()
        {
            //TODO: Update server
            await Task.Delay(3000);



            return true;
        }

        /// <summary>
        /// Save the new Email to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SaveEmailAsync()
        {
            //TODO: Update server
            await Task.Delay(3000);



            return true;
        }

        /// <summary>
        /// Save the new Username to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SaveUserNameAsync()
        {
            //TODO: Update server
            await Task.Delay(3000);



            return true;
        }

        /// <summary>
        /// Save the new Password to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SavePasswordAsync()
        {
            //TODO: Update server
            await Task.Delay(3000);



            return true;
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Updates original values from local data store
        /// </summary>
        /// <returns></returns>
        private async Task UpdateValuesFromLocalStoreAsync()
        {
            if (await ClientDataStore.HasCredentialsAsync())
            {
                var UserData = await ClientDataStore.GetLoginCredentialsAsync();

                //Make sure UI elements are created first
                if( Firstname == null ||
                    Lastname == null ||
                    Username == null ||
                    Email == null ||
                    Password == null)
                {
                    CreateUI();
                }

                Firstname.OriginalText = $"{UserData?.Firstname}";

                Lastname.OriginalText = $"{UserData?.Lastname}";

                Username.OriginalText = $"{UserData?.Username}";

                Email.OriginalText = $"{UserData?.Email}";
            }
        }

        /// <summary>
        /// Create UI elements, if needed
        /// </summary>
        private void CreateUI()
        {
            LogoutButtonText = "Logout";

            var loadingText = "...";

            Firstname = new TextEntryViewModel()
            {
                Label = "Firstname",
                OriginalText = loadingText,
                CommitAction = SaveFirstNameAsync
            };

            Lastname = new TextEntryViewModel()
            {
                Label = "Lastname",
                OriginalText = loadingText,
                CommitAction = SaveLastNameAsync
            };

            Username = new TextEntryViewModel()
            {
                Label = "Username",
                OriginalText = loadingText,
                CommitAction = SaveUserNameAsync
            };


            Password = new PasswordEntryViewModel()
            {
                Label = "Password",
                FakePassword = "*********",
                CommitAction = SavePasswordAsync
            };

            Email = new TextEntryViewModel()
            {
                Label = "Email",
                OriginalText = loadingText,
                CommitAction = SaveEmailAsync,
            };
        }

        #endregion
    }
}
