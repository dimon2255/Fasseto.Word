using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Fasseto.Word
{
    /// <summary>
    /// The NoFrameHistoryProperty  atatched property always clears navigation history
    /// </summary>
    public class PanelChildMarginProperty : BaseAttachedProperty<PanelChildMarginProperty, string>
    {
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //Get the frame
            var panel = (sender as Panel);

            //Wait for panel to load
            panel.Loaded += (s, e) =>
             {
                 //Loop each child
                 foreach (FrameworkElement child in panel.Children)
                 {
                     // Set it's margin to the given value
                     (child as FrameworkElement).Margin = (Thickness)new ThicknessConverter().ConvertFromString(args.NewValue as string);
                 }
             };
        }
    }
}
