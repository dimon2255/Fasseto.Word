using Fasetto.Word;
using Fasseto.Word.Core;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fasseto.Word
{
    /// <summary>
    /// View Model for the custom flat window
    /// </summary>
    public class DialogWindowViewModel : WindowViewModel
    {

        #region Public Properties

        /// <summary>
        /// Title of the Dialog
        /// </summary>
        public string Title { get; set; }
       

        /// <summary>
        /// Content to hist inside the Dialog
        /// </summary>
        public Control Content { get; set; }


        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>
        public DialogWindowViewModel(Window window) : base(window)
        {
            // Set mnimum height and width
            WindowMinimumHeight = 100;
            WindowMinimumWidth = 250;

            //set the title height
            TitleHeight = 30;
        }

        #endregion
    }
}
