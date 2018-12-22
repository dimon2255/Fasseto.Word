using System;
using System.Security;
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
        /// Orignal Password Before Editing
        /// </summary>
        public SecureString CurrentPassword{ get; set; }

        /// <summary>
        /// The current non-commited edited password
        /// </summary>
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// The confirm passsword 
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// Indicates whether curent control is in editing mode
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
        private void Save()
        {
 
            //Make sure current password is correct
            //TODO: this will come from the real backend
            var storedPassword = "Testing";

            if (storedPassword != CurrentPassword.Unsecure())
            {
                //Let this know passwords do not match
                UI.ShowMessage(new MessageBoxDialogViewModel()
                {
                    Message = "Current Password is invalid! Please, try again!",
                    OkText = "Ok",
                    Title = "Wrong Password entry"
                });
                return;
            }

            //Make sure passwords match when changing passwords
            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                //Let this know passwords do not match
                UI.ShowMessage(new MessageBoxDialogViewModel()
                {
                    Message = "Paswords do not match! Please, try again!",
                    OkText = "Ok",
                    Title = "Password mismatch"
                });
                return;
            }

            //Make sure passwords match when changing passwords
            if (NewPassword.Unsecure().Length == 0)
            {
                //Let this know passwords do not match
                UI.ShowMessage(new MessageBoxDialogViewModel()
                {
                    Message = "You ust enter password",
                    Title = "Password to short!",
                    OkText = "Ok"

                });
                return;
            }

            //Set the edited password to the current value
            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.Unsecure().ToCharArray())
            {
                CurrentPassword.AppendChar(c);
            }

            var actualCurrentPassword = CurrentPassword.Unsecure();
            var actualNewPassword = NewPassword.Unsecure();
            var actualConfirmPassword = ConfirmPassword.Unsecure();

            Editing = false;
        }

        #endregion
    }
}
