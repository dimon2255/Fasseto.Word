using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasseto.Word.Core
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
        /// Indicates whetther the login command is running its action asynchronously
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
            await RunCommand(() => this.IsLoginRunning, async () =>
            {
                await Task.Delay(1000);

                //Succcesfully logged in
                //TODO: Ask server for user's info

                IoC.Settings.Firstname = new TextEntryViewModel()
                {
                    Label = "Firstname",
                    OriginalText = $"Dimitri {DateTime.Now.ToLocalTime()}",
                };
                IoC.Settings.Lastname = new TextEntryViewModel()
                {
                    Label = "Lastname",
                    OriginalText = "Pankov",
                };
                IoC.Settings.Password = new PasswordEntryViewModel()
                {
                    Label = "Password",
                    FakePassword = "**********",
                };
                IoC.Settings.Email = new TextEntryViewModel()
                {
                    Label = "Email",
                    OriginalText = "dimon2255@gmail.com",
                };

                //Go to chat page
                IoC.Application.GoToPage(ApplicationPage.Chat);

                //var email = this.Email;

                ////IMPORTANT: never store unsecured password in variable like this.
                //var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
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
            IoC.Application.GoToPage(ApplicationPage.Register);

            await Task.Delay(1);
        }


        #endregion
    }
}
