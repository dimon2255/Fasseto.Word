using System.Windows.Input;

namespace Fasseto.Word.Core
{
    public class SideMenuViewModel : BaseViewModel
    {
        #region Commands

        /// <summary>
        /// Settings Command
        /// </summary>
        public ICommand SettingsButtonCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SideMenuViewModel()
        {
            SettingsButtonCommand = new RelayCommand(SettingsCommand);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// 
        /// </summary>
        private void SettingsCommand()
        {
            //Show Settings Menu
            IoC.Application.SettingsMenuVisible = true;
        }

        #endregion

    }
}
