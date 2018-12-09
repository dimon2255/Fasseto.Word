using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Fasseto.Word
{
    /// <summary>
    /// Creates a clipping region from the parent <see cref="Border"/<see cref="CornerRadius"/>>
    /// </summary>
    public class ClipFromBorderProperty : BaseAttachedProperty<ClipFromBorderProperty, bool>
    {
        #region Private Properties

        /// <summary>
        /// Called when Border Is Loaded
        /// </summary>
        private RoutedEventHandler mBorder_Loaded;

        /// <summary>
        /// Called when Border size changes
        /// </summary>
        private SizeChangedEventHandler mBorder_SizeChanged;

        #endregion


        protected override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //Get the frame
            var self = (sender as FrameworkElement);

            //check if we have a Parent border
            if(!(self.Parent is Border border))
            {
                Debugger.Break();
                return;
            }

            //setup loaded event
            mBorder_Loaded = (s1, e1) => Border_OnChange(s1, e1, self);

            //setup seize changed event
            mBorder_SizeChanged = (s1, e1) => Border_OnChange(s1, e1, self);

            //If true, hook into events
            if ((bool)e.NewValue)
            {
                border.Loaded += mBorder_Loaded;
                border.SizeChanged += mBorder_SizeChanged;
            }
            //Otherwise, unhook
            else
            {
                border.Loaded -= mBorder_Loaded;
                border.SizeChanged -= mBorder_SizeChanged;
            }

        }

        /// <summary> 
        /// Called when the Border is loaded or change size
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="child"></param>
        private void Border_OnChange(object sender, RoutedEventArgs e, FrameworkElement child)
        {
            //Get the Border
            var border = sender as Border;
                       
            //Check if we have an actual size
            if(border.ActualHeight == 0 && border.ActualWidth == 0)
            {
                return;
            }

            //Set a new child liiping area
            var rect = new RectangleGeometry();
            rect.RadiusX = rect.RadiusY = Math.Max(0, border.CornerRadius.TopLeft - (border.BorderThickness.Left * 0.5));

            //set the rectangle size to match child's actual size
            rect.Rect = new Rect(child.RenderSize);

            //assign clipping area to child
            child.Clip = rect;
        }
    }
}
