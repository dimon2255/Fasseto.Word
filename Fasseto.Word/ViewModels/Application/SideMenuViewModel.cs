using System.Windows.Input;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    public class SideMenuViewModel : BaseViewModel
    {
        #region Commands

        /// <summary>
        /// Settings Command
        /// </summary>
        public ICommand SettingsButtonCommand { get; set; }

        /// <summary>
        /// The command to change side menu to Chat
        /// </summary>
        public ICommand OpenChatCommand { get; set; }

        /// <summary>
        /// The command to change side menu to Contacts
        /// </summary>
        public ICommand OpenContactsCommand { get; set; }

        /// <summary>
        /// The command to change side menu to Media
        /// </summary>
        public ICommand OpenMediaCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuViewModel()
        {
            SettingsButtonCommand = new RelayCommand(OpenSettings);
            OpenChatCommand = new RelayCommand(OpenChat);
            OpenContactsCommand  = new RelayCommand(OpenContacts);
            OpenMediaCommand = new RelayCommand(OpenMedia);

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Opens a settings menu
        /// </summary>
        private void OpenSettings()
        {
            //Show Settings Menu
            ViewModelApplication.SettingsMenuVisible = true;
        }

        /// <summary>
        /// Opens chat
        /// </summary>
        private void OpenChat()
        {
            ViewModelApplication.CurrentSideMenuContent = Core.SideMenuContent.Chat;
        }

        /// <summary>
        /// Opens Contacts
        /// </summary>
        private void OpenContacts()
        {
            ViewModelApplication.CurrentSideMenuContent = Core.SideMenuContent.Contacts;
        }

        /// <summary>
        /// Opens Media
        /// </summary>
        private void OpenMedia()
        {
            ViewModelApplication.CurrentSideMenuContent = Core.SideMenuContent.Media;            
        }

        #endregion

    }
}
