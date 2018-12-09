using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Fasseto.Word
{
    /// <summary>
    /// Match the label width of all text entry control in the panel
    /// </summary>
    public class TextEntryWidthMatcherProperty : BaseAttachedProperty<TextEntryWidthMatcherProperty, bool>
    {
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //Get the frame
            var panel = (sender as Panel);

            //Call SetWidths Initially (this also helps design time to work)
            SetWidths(panel);

            //Wait for panel to load
            RoutedEventHandler onLoaded = null;
            onLoaded  = (s, e) =>
             {
                 //Unhook
                 panel.Loaded -= onLoaded;

                 //SetWidths
                 SetWidths(panel);

                 //Loop each child
                 foreach (FrameworkElement control in panel.Children)
                 {
                     if ((control is TextEntryControl))
                     {
                         var textentry = (TextEntryControl)control;

                         textentry.Label.SizeChanged += (ee, ss) =>
                         {
                             SetWidths(panel);
                         };
                     }
                 }
             };

            //Pass a function pointer to panel Loaded
            panel.Loaded += onLoaded;
        }

        /// <summary>
        /// Update all child TextEntry Controls, so their widths match the largets width in the group
        /// </summary>
        private void SetWidths(Panel panel)
        {
            //Keep the track of the maximum width
            var maxSize = 0d;

            //Loop each child and fin max width
            foreach (var child in panel.Children)
            {
                if (child is TextEntryControl)
                {
                    var textentry = (TextEntryControl)child;

                    //Find Max size
                    maxSize = Math.Max(maxSize, textentry.Label.RenderSize.Width + 
                                                           textentry.Margin.Left + 
                                                           textentry.Margin.Right);

                }

            }

            //Loop each child and set the width to max value
            foreach (var child in panel.Children)
            {
                if (child is TextEntryControl)
                {
                    var textentry = (TextEntryControl)child;

                    textentry.LabelLength = (GridLength)new GridLengthConverter().ConvertFromString(maxSize.ToString());
                    
                }
            }

        }
    }
}
