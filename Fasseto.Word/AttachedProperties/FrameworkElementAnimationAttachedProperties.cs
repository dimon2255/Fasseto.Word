

using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
         where Parent : BaseAttachedProperty<Parent, bool>, new()
    {

        #region Public Properties

        /// <summary>
        /// A flag indicating whether its first time property has been loaded.
        /// </summary>
        public bool IsFirstLoad { get; set; } = true;

        #endregion


        /// <summary>
        /// Executes when value is updated even if it is the same value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        protected override void OnValueUpdated(DependencyObject sender, object value)
        {
            //If sender is not FrameworkElement  return
            if (!(sender is FrameworkElement element))
                return;

            //Don't fire if the value doesn't change
            if ((bool)sender.GetValue(ValueProperty) == (bool)value && !IsFirstLoad)
                return;

            //Initially hide the element.
            element.Visibility = Visibility.Hidden;

            // On First Load
            if (IsFirstLoad)
            {
                // Create a single self-unhookable event
                //for the element Loaded event
                RoutedEventHandler OnLoaded = null;
                OnLoaded = (ss, ee) =>
                {
                    //Unhook ourselves
                    element.Loaded -= OnLoaded;

                    //Do the desired animation
                    DoAnimation(element, (bool)value);

                    //No longer in first load
                    IsFirstLoad = false;
                };

                //Hook into the loaded event of the element
                element.Loaded += OnLoaded;
            }
            else
            {
                DoAnimation(element, (bool)value);
            }
        }

        /// <summary>
        /// The animation method that is fired when the value is changed
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
        
        /// <summary>
        /// The animation method that is fired when the value is changed
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value, bool firstload) { }

    }

    /// <summary>
    /// Fades in image once the source changes
    /// </summary>
    public class FadeInImageOnLoadProperty : AnimateBaseProperty<FadeInImageOnLoadProperty>
    {
        protected override void OnValueUpdated(DependencyObject sender, object value)
        {
            //Make sure it is an image
            if(!(sender is Image image))
                return;

            if ((bool)value)
                image.TargetUpdated += Image_TargetUpdated;
            else
                image.TargetUpdated -= Image_TargetUpdated;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Image_TargetUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            //Fade in Image
            await (sender as Image).FadeInAsync(1);
        }
    }


    /// <summary>
    /// Class lets us animate an element --> slide in from left 
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Left, IsFirstLoad, IsFirstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                //Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideOutDirection.Left, IsFirstLoad ? 0 : 0.3f, keepMargin: false);
            }
        }
    }

    /// <summary>
    /// Animates and slides from right
    /// </summary>
    public class AnimateSlideInFromRightProperty : AnimateBaseProperty<AnimateSlideInFromRightProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, IsFirstLoad, IsFirstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                //Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideOutDirection.Right, IsFirstLoad ? 0 : 0.3f, keepMargin: false);
            }
        }
    }

    /// <summary>
    /// Animates and slides from right and keeps the margin
    /// </summary>
    public class AnimateSlideInFromRightMargingProperty : AnimateBaseProperty<AnimateSlideInFromRightMargingProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Right, IsFirstLoad, IsFirstLoad ? 0 : 0.3f, keepMargin: true);
            }
            else
            {
                //Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideOutDirection.Right, IsFirstLoad ? 0 : 0.3f, keepMargin: true);
            }
        }
    }

    /// <summary>
    /// Class lets us animate an element --> slide up from bottom to show, sliding out from top tp hide
    /// </summary>
    public class AnimateSlideInFromBottomProperty : AnimateBaseProperty<AnimateSlideInFromBottomProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, IsFirstLoad, IsFirstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                //Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideOutDirection.Bottom, IsFirstLoad ? 0 : 0.3f, keepMargin: false);
            }
        }
    }

    /// <summary>
    /// Class lets us animate an element --> slide up from top to show, sliding out from top tp hide
    /// </summary>
    public class AnimateSlideInFromTopProperty : AnimateBaseProperty<AnimateSlideInFromTopProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Top, IsFirstLoad, IsFirstLoad ? 0 : 0.3f, keepMargin: false);
            }
            else
            {
                //Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideOutDirection.Top, IsFirstLoad ? 0 : 0.3f, keepMargin: false);
            }
        }
    }

    /// <summary>
    /// Class lets us animate an element --> slide up from bottom on load
    /// </summary>
    public class AnimateSlideInFromBottomOnLoadProperty : AnimateBaseProperty<AnimateSlideInFromBottomOnLoadProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, !value, !value? 0 : 0.3f, keepMargin: false);
        }
    }

    /// <summary>
    /// Class lets us animate an element --> slide up from bottom to show, sliding out from top tp hide
    /// </summary>
    public class AnimateSlideInFromBottomMarginProperty : AnimateBaseProperty<AnimateSlideInFromBottomMarginProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.SlideAndFadeInAsync(AnimationSlideInDirection.Bottom, IsFirstLoad, IsFirstLoad ? 0 : 0.3f, keepMargin: true);
            }
            else
            {
                //Animate out
                await element.SlideAndFadeOutAsync(AnimationSlideOutDirection.Bottom, IsFirstLoad ? 0 : 0.3f, keepMargin: true);
            }
        }
    }

    /// <summary>
    /// Animates a framework element fading in on show and fading out on hide
    /// </summary>
    public class AnimateFadeInOutProperty : AnimateBaseProperty<AnimateFadeInOutProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                //Animate in
                await element.FadeInAsync(IsFirstLoad ? 0 : 0.3f);
            }
            else
            {
                //Animate out
                await element.FadeOutAsync(IsFirstLoad ? 0 : 0.3f);
            }
        }
    }
}
