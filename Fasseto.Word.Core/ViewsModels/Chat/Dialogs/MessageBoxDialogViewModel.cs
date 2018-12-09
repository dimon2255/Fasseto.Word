using System;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Details for the message ox dialog
    /// </summary>
    public class MessageBoxDialogViewModel : BaseDialogViewModel
    {
        #region Command Methods

        /// <summary>
        /// Executes when Ok Button is Clicked
        /// </summary>
        private void OkCommand()
        {
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Message of the Dailog
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Ok Button Text
        /// </summary>
        public string OkText { get; set; }


        #endregion
    }
}
