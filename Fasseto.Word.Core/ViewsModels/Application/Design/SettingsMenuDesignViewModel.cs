using System.Windows.Input;

namespace Fasseto.Word.Core
{
    public class SettingsMenuDesignViewModel : SettingsMenuViewModel
    {

        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SettingsMenuDesignViewModel Instance => new SettingsMenuDesignViewModel();
        #endregion


        #region Constructor

        public SettingsMenuDesignViewModel()
        {
            //Bind Settinds Control VMs
            Firstname = new TextEntryViewModel()
            {
                Label = "Firstname",
                OriginalText = "Dimitri",
            };
            Lastname = new TextEntryViewModel()
            {
                Label = "Lastname",
                OriginalText = "Pankov",
            };
            Password = new PasswordEntryViewModel()
            {
                Label = "Password",
                FakePassword = "**********",
            };
            Email = new TextEntryViewModel()
            {
                Label = "Email",
                OriginalText = "dimon2255@gmail.com",
            };
        }

        #endregion
    }

}