using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{
    /// <summary>
    /// Scroll an Items Control its DataContext changes
    /// </summary>
    public class AutoScrollToBottomProperty : BaseAttachedProperty<AutoScrollToBottomProperty, bool>
    {
        /// <summary>
        /// Automatically scrolls to bottom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //Make sure sender is Control, if not return
            if (!(sender is ScrollViewer control))
                return;

            //Focus the control when it is loaded
            control.ScrollChanged -= Control_ScrollChanged;
            control.ScrollChanged += Control_ScrollChanged;
        }

        /// <summary>
        /// Scroll Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scroll = sender as ScrollViewer;

            //If we are close enough to bottom
            if(scroll.ScrollableHeight - scroll.VerticalOffset < 20)
                scroll.ScrollToEnd();
        }
    }

    /// <summary>
    /// Scroll an Items Control its DataContext changes
    /// </summary>
    public class ScrollToBottomOnLoadProperty : BaseAttachedProperty<ScrollToBottomOnLoadProperty, bool>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //Make sure sender is Control, if not return
            if (!(sender is ScrollViewer control))
                return;

            //Focus the control when it is loaded
            control.DataContextChanged -= Control_DataContextChanged;
            control.DataContextChanged += Control_DataContextChanged;
        }

        private void Control_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Scroll to Bottom
            ((ScrollViewer)sender).ScrollToBottom();
        }
    }
}
