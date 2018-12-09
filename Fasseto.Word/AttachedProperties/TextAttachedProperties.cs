using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Fasseto.Word
{
    /// <summary>
    /// Focuses this elemnt onload
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //Make sure sender is Control, if not return
            if (!(sender is Control control))
                return;

            //Focus the control when it is loaded
            control.Loaded += (s, e) => control.Focus();
        }
    }

    /// <summary>
    /// Focuses this elemnt onload
    /// </summary>
    public class FocusProperty : BaseAttachedProperty<FocusProperty, bool>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //Make sure sender is Control, if not return
            if (!(sender is Control control))
                return;

            //Focus the control when it is loaded
            control.IsVisibleChanged += (s, e) => control.Focus();
        }
    }

    /// <summary>
    /// Focuses this elemnt onload
    /// </summary>
    public class FocusAndSelectProperty : BaseAttachedProperty<FocusAndSelectProperty, bool>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //Make sure sender is Control, if not return
            if (!(sender is TextBoxBase control) || !(sender is PasswordBox))
                return;

            if((bool)args.NewValue == true)
            {
                //Focus
                control.Focus();

                //Select all text
                control.SelectAll();
            }
        }
    }


}
