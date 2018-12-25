using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Fasseto.Word.Core;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    /// <summary>
    /// ViewModel for any control that allows text entry
    /// </summary>
    public class PasswordEntryViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Label to Identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Fake Password 
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        /// Current Password Hint Text
        /// </summary>
        public string CurrentPasswordHintText { get; set; }

        /// <summary>
        /// New Password Hint Text
        /// </summary>
        public string NewPasswordHintText { get; set; }

        /// <summary>
        /// Confirm Password Hint Text
        /// </summary>
        public string ConfirmPasswordHintText { get; set; }

        /// <summary>
        /// Original Password Before Editing
        /// </summary>
        public SecureString CurrentPassword{ get; set; }

        /// <summary>
        /// The current non-commited edited password
        /// </summary>
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// The confirm password 
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// Indicates whether current control is in editing mode
        /// </summary>
        public bool Editing { get; set; }

        #endregion

        /// <summary>
        /// Command  the Edited text
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

        /// <summary>
        /// Indicates if the current control is pending an update
        /// </summary>
        public bool Working { get; set; }

        /// <summary>
        /// Action to Run when save button is clicked
        /// Returns true if save was successful, or false otherwise
        /// </summary>
        public Func<Task<bool>> CommitAction { get; set; }

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PasswordEntryViewModel()
        {
            //Create the commands
            SaveCommand = new RelayCommand(Save);
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);

            //Set Defaults
            //TODO: Replace with localization
            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        private void Edit()
        {
            //Go into editing mode
            Editing = true;
        }

        /// <summary>
        /// Cancels out edit mode
        /// </summary>
        private void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Save Text -> Commit
        /// </summary>
        private async void Save()
        {
            //Store result of a commit call
            var result = default(bool);

            await RunCommandAsync(() => Working, async () =>
            {
                //while working come out of editing mode
                Editing = false;

                //try and do the work
                result = CommitAction == null ? true : await CommitAction();

            }).ContinueWith(t =>
            {
                if (!result)
                {
                    Editing = true;
                }
            });
        }

        #endregion
    }
}
