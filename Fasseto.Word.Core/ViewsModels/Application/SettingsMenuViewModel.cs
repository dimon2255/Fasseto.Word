using System.Windows.Input;

namespace Fasseto.Word.Core
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
        /// Command fot he back button
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

            //TODO: remove at a later date when will have real data coming to us


            LogoutButtonText = "Logout";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Executes when back command is fired
        /// </summary>
        private void Close()
        {
            //SEt the Settings menu visibility to false, which in turn hides the menu
            IoC.Application.SettingsMenuVisible = false;
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
            IoC.Application.GoToPage(ApplicationPage.Login);
        }

        /// <summary>
        /// Clears user's data
        /// </summary>
        public void ClearUserData()
        {
            //Clear all viewmodels 
            Firstname = null;
            Lastname = null;
            Password = null;
            Email = null;
        }

        #endregion
    }
}
