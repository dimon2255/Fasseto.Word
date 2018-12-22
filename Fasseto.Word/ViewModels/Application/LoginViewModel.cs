using Dna;
using Fasseto.Word.Core;
using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    /// <summary>
    /// View Model for the custom flat window
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Email of the User
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Secure Password of the User
        /// </summary>
        public SecureString Password { get; set; }

        /// <summary>
        /// Indicates whether the login command is running its action asynchronously
        /// </summary>
        public bool IsLoginRunning { get; set; }


        #endregion
        
        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }


        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor for login viewmodel
        /// </summary>
        /// <param name="window"></param>
        public LoginViewModel()
        {
            this.LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            this.RegisterCommand = new RelayCommand(async () => await RegisterAsync());

        }

        /// <summary>
        /// Attempt to login the user
        /// </summary>
        /// <param name="parameter"><see cref="SecureString"/></param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommand(() => this.IsLoginRunning, async() =>
            {
                //await Task.Delay(1000);

                var result = await WebRequests.PostAsync<ApiResponse<LoginResultApiModel>>(
                                                                    "http://localhost:5000/api/login",
                                                                     new LoginCredentialsApiModel()
                                                                     {
                                                                         UsernameOrEmail = Email,
                                                                         Password = (parameter as IHavePassword).SecurePassword.Unsecure()
                                                                     }
                                          
                );

                //Check for errors
                if (await result.DisplayErrorOnFailureAsync("Failed to login"))
                {
                    return;
                }

                //Get Response
                var UserData = result.ServerResponse.Response;

                //Do all necessary steps required to log in
                await ViewModelApplication.HandleSuccessfulLoginAsync(UserData);
            });
        }

        /// <summary>
        /// Takes the user to the Register Page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            //IoC.Application.IsSideMenuVisible ^= true;

            // Go to a register page.
            ViewModelApplication.GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }


        #endregion
    }
}
