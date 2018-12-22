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
            ViewModelApplication.SettingsMenuVisible = true;
        }

        #endregion

    }
}
