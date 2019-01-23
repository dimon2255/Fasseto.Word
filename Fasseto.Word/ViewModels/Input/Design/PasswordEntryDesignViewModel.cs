using System.Collections.Generic;

namespace Fasseto.Word
{
    /// <summary>
    /// The design-time data for a <see cref="PasswordEntryDesignViewModel"/>
    /// </summary>
    public class PasswordEntryDesignViewModel : PasswordEntryViewModel
    {

        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static PasswordEntryDesignViewModel Instance => new PasswordEntryDesignViewModel();
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PasswordEntryDesignViewModel()
        {
            FakePassword = "*********";
            Label = "Password";
        }

        #endregion  
    }
}
