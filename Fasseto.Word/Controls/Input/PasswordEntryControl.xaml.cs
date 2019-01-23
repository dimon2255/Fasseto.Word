using Fasseto.Word.Core;
using System;
using System.Diagnostics;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for PasswordEntryControl.xaml
    /// </summary>
    public partial class PasswordEntryControl : UserControlBase<PasswordEntryViewModel>
    {

        #region Dependency Properties

        /// <summary>
        /// The label width of a control
        /// </summary>
        public GridLength LabelLength
        {
            get => (GridLength)GetValue(LabelLengthProperty);
            set => SetValue(LabelLengthProperty, value);
        }

        // Using a DependencyProperty as the backing store for LabelLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelLengthProperty =
                                                DependencyProperty.Register("LabelLength", typeof(GridLength),
                                                typeof(PasswordEntryControl),
                                                new PropertyMetadata(GridLength.Auto,
                                                LabelWidthChanged));

        #endregion


        #region Dependency Callbacks

        /// <summary>
        /// Callback function when dependency property has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void LabelWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //Set the column definition length to the new value
                (d as PasswordEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch (Exception)
            {
                //Make the developer aware of potential issue
                Debugger.Break();

                (d as PasswordEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PasswordEntryControl()
        {
            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Get the new SecurePassword
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.NewPassword = NewPassword.SecurePassword;
        }

        /// <summary>
        /// Get the Current password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if(DataContext is PasswordEntryViewModel viewModel)
                viewModel.CurrentPassword = CurrentPassword.SecurePassword;
        }

        /// <summary>
        /// Get Confirm Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is PasswordEntryViewModel viewModel)
                viewModel.ConfirmPassword = ConfirmPassword.SecurePassword;

        }
    }
}
