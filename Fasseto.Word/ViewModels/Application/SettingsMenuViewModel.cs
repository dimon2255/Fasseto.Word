using Dna;
using Fasseto.Word.Core;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

using static Fasseto.Word.DI;
using static Dna.Framework;
using System.Linq.Expressions;

namespace Fasseto.Word
{
    public class SettingsMenuViewModel : BaseViewModel
    {

        #region Private Properties

        /// <summary>
        /// Loading text
        /// </summary>
        private string loadingText = "...";

        #endregion

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


        #region Transactional Properties

        /// <summary>
        /// Indicates if the first name is being saved
        /// </summary>
        public bool FirstNameIsSaving { get; set; }

        /// <summary>
        /// Indicates if the last name is being saved
        /// </summary>
        public bool LastNameIsSaving { get; set; }

        /// <summary>
        /// Indicates if the user name is being saved
        /// </summary>
        public bool UserNameIsSaving { get; set; }

        /// <summary>
        /// Indicates if the users email is being saved
        /// </summary>
        public bool EmailIsSaving { get; set; }

        /// <summary>
        /// Indicates if the users password is being changed
        /// </summary>
        public bool PasswordIsSaving { get; set; }

        /// <summary>
        /// Indicates if the settings are currently being loaded
        /// </summary>
        public bool SettingsLoading { get; set; }

        /// <summary>
        /// Indicates that user is being logged out
        /// </summary>
        public bool LogingOut { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsMenuViewModel()
        {
            //Create commands
            CloseCommand = new RelayCommand(Close);
            ClearUserDataCommand = new RelayCommand(ClearUserData);

            //Async command Actions
            LogoutCommand = new RelayCommand(async () => await LogoutAsync());
            LoadCommand = new RelayCommand(async () => await LoadAsync());
            SaveFirstNameCommand = new RelayCommand(async () => await SaveFirstNameAsync());
            SaveLastNameCommand = new RelayCommand(async () => await SaveLastNameAsync());
            SaveUsernameCommand = new RelayCommand(async () => await SaveUserNameAsync());
            SaveEmailCommand = new RelayCommand(async () => await SaveEmailAsync());

            LogoutButtonText = "Logout";

            //Creates UI elements            
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

            //Lock the command ignore all others, while processing
            await RunCommandAsync(() => LogingOut, async () =>
            {
                await ClientDataStore.ClearAllLoginCredentialsAsync();

                //Clean all application level data
                ClearUserData();

                //Redirects the user to the login page
                ViewModelApplication.GoToPage(ApplicationPage.Login);
            });
        }

        /// <summary>
        /// Clears user's data
        /// </summary>
        public void ClearUserData()
        {
            //Clear all view models 
            Firstname.OriginalText = loadingText;
            Lastname.OriginalText = loadingText;
            Username.OriginalText = loadingText;
            Email.OriginalText = loadingText;
        }

        /// <summary>
        /// Loads User Data Store
        /// </summary>
        public async Task LoadAsync()
        {
            //Lock the command ignore all others, while processing
            await RunCommandAsync(() => SettingsLoading, async () =>
            {
                //Create a scoped client data store
                var scopedDataStore = ClientDataStore;

                //Update values from local cached 
                await UpdateValuesFromLocalStoreAsync(scopedDataStore);

                //Get user token
                var token = (await scopedDataStore.GetLoginCredentialsAsync())?.Token;

                //If we don't have a token (so we are not logged in...)
                if (string.IsNullOrEmpty(token))
                {
                    return;
                }

                // Load user profile details from server
                var result = await WebRequests.PostAsync<ApiResponse<UserProfileDetailsApiModel>>(
                            RouteHelpers.GetAbsoluteRoute(ApiRoutes.GetUserProfile),
                            bearerToken: token);

                //Check for errors
                if (await result.DisplayErrorOnFailureAsync("Failed to load user data"))
                {
                    return;
                }
                //TODO: Should we check if the values are different to saving values?!

                //Create data mode from the response
                var dataModel = result.ServerResponse.Response.ToLoginCredentialsDataModel();

                //Re-add our known token
                dataModel.Token = token;

                //Store this in client data store
                await scopedDataStore.SaveLoginCredentialsAsync(dataModel);

                //Update values from local cache
                await UpdateValuesFromLocalStoreAsync(scopedDataStore);
            });
        }


        /// <summary>
        /// Save the new FirstName to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SaveFirstNameAsync()
        {
            //Lock the command ignore all others, while processing
            return await RunCommandAsync(() => FirstNameIsSaving, async () =>
            {
                return await UpdateUserCredentialsValueAsync(
                    //Display name
                    "First Name",
                    //Update the firstname
                    (credentials) => credentials.Firstname,
                    //To new value
                    Firstname.OriginalText,
                    //Set API Model value
                    (apiModel, newValue) => apiModel.Firstname = newValue
                    );
            });
        }

        /// <summary>
        /// Save the new LastName to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SaveLastNameAsync()
        {
            //Lock the command ignore all others, while processing
            return await RunCommandAsync(() => LastNameIsSaving, async () =>
            {
                return await UpdateUserCredentialsValueAsync(
                    //Display name
                    "Last Name",
                    //Update the lastname
                    (credentials) => credentials.Lastname,
                    //To new value
                    Lastname.OriginalText,
                    //Set API Model value
                    (apiModel, newValue) => apiModel.Lastname = newValue
                    );
            });
        }

        /// <summary>
        /// Save the new Email to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SaveEmailAsync()
        {
            //Lock the command ignore all others, while processing
            return await RunCommandAsync(() => EmailIsSaving, async () =>
            {
                return await UpdateUserCredentialsValueAsync(
                    //Display name
                    "Email",
                    //Update the email
                    (credentials) => credentials.Email,
                    //To new value
                    Email.OriginalText,
                    //Set API Model value
                    (apiModel, newValue) => apiModel.Email = newValue
                    );
            });
        }

        /// <summary>
        /// Save the new Username to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SaveUserNameAsync()
        {
            //Lock the command ignore all others, while processing
            return await RunCommandAsync(() => UserNameIsSaving, async () =>
            {
                return await UpdateUserCredentialsValueAsync(
                    //Display name
                    "User Name",
                    //Update the username
                    (credentials) => credentials.Username,
                    //To new value
                    Username.OriginalText,
                    //Set API Model value
                    (apiModel, newValue) => apiModel.Username = newValue
                    );
            });
        }

        /// <summary>
        /// Save the new Password to the server
        /// </summary>
        /// <param name="self">The details of the viewmodel</param>
        /// <returns></returns>
        public async Task<bool> SavePasswordAsync()
        {
            //Lock the command ignore all others, while processing
            return await RunCommandAsync(() => PasswordIsSaving, async () =>
            {
                //Log it
                Logger.LogDebugSource($"Changing password...");

                //Get the current known credentials...
                var credentials = await ClientDataStore.GetLoginCredentialsAsync();

                //Make sure the user has entered the same password
                if (Password.NewPassword.Unsecure() != Password.ConfirmPassword.Unsecure())
                {
                    //Display error
                    await UI.ShowMessage(new MessageBoxDialogViewModel()
                    {
                        //TODO: Localization
                        Title = "Passwords do not match!",
                        Message = "New Password and Confirm Password, do not match. Try Again!",
                        OkText = "Ok"
                    });

                    return false;
                }

                //Update the server with the new password
                var result = await WebRequests.PostAsync<ApiResponse>(
                    //Set URL
                    RouteHelpers.GetAbsoluteRoute(ApiRoutes.UpdateUserPassword),
                    //Create API Model
                    new UpdateUserPasswordApiModel()
                    {
                        CurrentPassword = Password.CurrentPassword.Unsecure(),
                        NewPassword = Password.NewPassword.Unsecure()
                    },
                    //Pass in User Token
                    bearerToken: credentials.Token);

                //Check for errors
                if (await result.DisplayErrorOnFailureAsync($"Failed to change password"))
                {
                    Logger.LogDebugSource($"Failed to change password {result.ErrorMessage}");

                    return false;
                }

                //Log it
                Logger.LogDebugSource($"Successfully changed password");

                return true;
            });
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Updates original values from local data store
        /// </summary>
        /// <returns></returns>
        private async Task UpdateValuesFromLocalStoreAsync(IClientDataStore scopedDataStore)
        {
            if (await scopedDataStore.HasCredentialsAsync())
            {
                var UserData = await scopedDataStore.GetLoginCredentialsAsync();

                Firstname.OriginalText = $"{UserData?.Firstname}";

                Lastname.OriginalText = $"{UserData?.Lastname}";

                Username.OriginalText = $"{UserData?.Username}";

                Email.OriginalText = $"{UserData?.Email}";
            }
        }

        /// <summary>
        /// Updates users display name value
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name=""></param>
        /// <returns></returns>
        private async Task<bool> UpdateUserCredentialsValueAsync(string displayName,
                                                            Expression<Func<LoginCredentialsDataModel, string>> propertyToUpdate,
                                                            string newValue,
                                                            Action<UpdateUserProfileApiModel, string> setApiModel)
        {
            Logger.LogDebugSource($"Saving {displayName}...");

            //Get known credentials
            var credentials = await ClientDataStore.GetLoginCredentialsAsync();

            //Get the property to update
            var toUpdate = propertyToUpdate.GetPropertyValue(credentials);

            Logger.LogDebugSource($"{displayName} currently {toUpdate}, updating to {newValue}");

            //Check if there any changes
            if (toUpdate == newValue)
            {
                Logger.LogDebugSource($"{displayName} the same, ignoring...");
                return true;
            }

            //Set the property
            propertyToUpdate.SetPropertyValue(newValue, credentials);

            //Create update details
            var updateApiModel = new UpdateUserProfileApiModel();

            //ask the caller to set appropriate value
            setApiModel(updateApiModel, newValue);

            var result = await WebRequests.PostAsync<ApiResponse>(
                RouteHelpers.GetAbsoluteRoute(ApiRoutes.UpdateUserProfile),
                 updateApiModel
                , bearerToken: credentials.Token);

            if (await result.DisplayErrorOnFailureAsync($"Failed to update {displayName}"))
            {

                Logger.LogDebugSource($"Failed to update {displayName}. {result.ErrorMessage}");

                return false;
            }

            Logger.LogDebugSource($"Successfully updated {displayName}, saving to local cache...");

            //Save Credentials to local cache store
            await ClientDataStore.SaveLoginCredentialsAsync(credentials);

            return true;
        }

        #endregion
    }
}
