﻿using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// View Model for the custom flat window
    /// </summary>
    public class RegisterViewModel : BaseViewModel
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
        /// Secure Password of the User
        /// </summary>
        public SecureString ConfirmPassword { get; set; }


        /// <summary>
        /// Indicates whetther the login command is running its action asynchronously
        /// </summary>
        public bool IsRegisterRunning { get; set; }

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
        public RegisterViewModel()
        {
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
            LoginCommand = new RelayCommand(async () => await LoginAsync());

        }

        /// <summary>
        /// Attempts to register new user
        /// </summary>
        /// <param name="parameter"><see cref="SecureString"/></param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommand(() => this.IsRegisterRunning, async () =>
            {
                await Task.Delay(5000);
            });
        }

        /// <summary>
        /// Takes the user to the Login Page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            // Go to a login page.
            IoC.Application.GoToPage(ApplicationPage.Login);

            await Task.Delay(1);
        }


        #endregion
    }
}
