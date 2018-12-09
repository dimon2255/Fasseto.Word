using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Fasseto.Word
{
    /// <summary>
    /// The NoFrameHistoryProperty  atatched property always clears navigation history
    /// </summary>
    public class NoFrameHistoryProperty : BaseAttachedProperty<NoFrameHistoryProperty, bool>
    {
        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //Get the frame
            var frame = (sender as Frame);

            //Remove the default navigation utility 
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            //Clear history on Navigate
            frame.Navigated += (ss, ee) =>
            {
                ((Frame)ss).NavigationService.RemoveBackEntry();
            };
        }
    }
}
