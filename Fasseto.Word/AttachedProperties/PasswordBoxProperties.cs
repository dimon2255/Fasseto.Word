using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{

    /// <summary>
    /// The MonitorAttached Property
    /// </summary>
    public class MonitorPasswordProperty : BaseAttachedProperty<MonitorPasswordProperty, bool>
    {
        /// <summary>
        /// Overriden Base class method for listening to Value changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            // Make sure the caller is of desired type. not null
            var passwordBox = (sender as PasswordBox);
            if (passwordBox == null)
                return;

            //Remove previuis listeners
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;


            //Start listening oiut for password changes
            if ((bool)args.NewValue)
            {
                //Set default value
                HasTextProperty.SetValue(passwordBox);

                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Fired when passowrd vakue changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText Attached Property <see cref="PasswordBox"/>
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            var passwordBox = (sender as PasswordBox);

            HasTextProperty.SetValue(passwordBox, passwordBox.SecurePassword.Length > 0);
        }
    }
}
