using System;
using System.Windows.Input;

namespace Fasseto.Word
{
    /// <summary>
    /// Details for the message ox dialog
    /// </summary>
    public class MessageBoxDialogDesignViewModel : MessageBoxDialogViewModel
    {

        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MessageBoxDialogDesignViewModel Instance => new MessageBoxDialogDesignViewModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MessageBoxDialogDesignViewModel()
        {
            Message = "Design time message are fun :)";
            OkText = "Ok";
        }

        #endregion

    }
}
