using System;
using System.Windows.Input;

namespace Fasseto.Word
{
    /// <summary>
    /// ViewModel for any control that allows text entry
    /// </summary>
    public class TextEntryViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Label to Identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Original Text Before Editing
        /// </summary>
        public string OriginalText { get; set; }

        /// <summary>
        /// The current non-committed edited text
        /// </summary>
        public string EditedText { get; set; }

        /// <summary>
        /// Indicates whether current control is in editing mode
        /// </summary>
        public bool Editing { get; set; }

        #endregion

        /// <summary>
        /// Command for saving the Edited text
        /// </summary>
        public ICommand SaveCommand { get; set; }


        /// <summary>
        /// Command for putting the control into the editing mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Command for Canceling out edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextEntryViewModel()
        {
            //Create the commands
            SaveCommand = new RelayCommand(Save);
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);



        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        private void Edit()
        {
            //Show the user original Text
            EditedText = OriginalText;

            //Go into editing mode
            Editing = true;
        }

        /// <summary>
        /// Cances out edit mode
        /// </summary>
        private void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Save Text -> Commit
        /// </summary>
        private void Save()
        {
            //TODO:
            OriginalText = EditedText;

            Editing = false;
        }

        #endregion
    }
}
