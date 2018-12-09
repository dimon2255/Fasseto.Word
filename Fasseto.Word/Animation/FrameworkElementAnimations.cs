using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasseto.Word
{
    /// <summary>
    /// Helpers to animate framework elements in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {

        #region Slide/Fade In/Out Animations

        /// <summary>
        /// Animation to slide in from left
        /// </summary>
        /// <param name="element">Element to animate</param>
        /// <param name="seconds">Duration of the naimation in seconds</param>
        /// <param name="keepMargin">Whether to keep margin or not</param>
        /// <param name="distanceToSlide">The animation width to animate to</param>
        /// <returns>Task for Continuation work</returns>
        public static async Task SlideAndFadeInAsync(this FrameworkElement element, AnimationSlideInDirection direction, bool firstload, float seconds = 0.3f, bool keepMargin = true, int distanceToSlide = 0)
        {
            //Create a storyboard
            var sb = new Storyboard();
            
            switch (direction)
            {
                case AnimationSlideInDirection.Left:
                    //Add a slide from right animation
                    sb.AddSlideFromLeft(seconds, distanceToSlide == 0 ? element.ActualWidth : distanceToSlide, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Right:
                    //Add a slide from right animation
                    sb.AddSlideFromRight(seconds, distanceToSlide == 0 ? element.ActualWidth : distanceToSlide, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Top:
                    //Add a slide to bottom animation
                    sb.AddSlideFromTop(seconds, distanceToSlide == 0 ? element.ActualWidth : distanceToSlide, keepMargin: keepMargin);
                    break;
                case AnimationSlideInDirection.Bottom:
                    //Add a slide from bottom animation
                    sb.AddSlideFromBottom(seconds, distanceToSlide == 0 ? element.ActualWidth : distanceToSlide, keepMargin: keepMargin);
                    break;
            }

            //Adds a slide from right animation
            sb.AddFadeIn(seconds);

            //Start the animation
            sb.Begin(element);

            //Make the page visible
            if(seconds != 0 || firstload)
                element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slides Out and Fades Out Animation
        /// </summary>
        /// <param name="element">Element to animate</param>
        /// <param name="seconds">Duration of the naimation in seconds</param>
        /// <param name="keepMargin">Whether to keep margin or not</param>
        /// <param name="distanceToSlide">The animation width to animate to</param>
        /// <returns>Task for Continuation work</returns>
        public static async Task SlideAndFadeOutAsync(this FrameworkElement element, AnimationSlideOutDirection direction, float seconds = 0.3f, bool keepMargin = true, int distanceToSlide = 0)
        {
            //Create a storyboard
            var sb = new Storyboard();

            switch (direction)
            {
                case AnimationSlideOutDirection.Left:
                    //Add a slide from right animation
                    sb.AddSlideToLeft(seconds, distanceToSlide == 0 ? element.ActualWidth : distanceToSlide, keepMargin: keepMargin);
                    break;
                case AnimationSlideOutDirection.Right:
                    //Add a slide from right animation
                    sb.AddSlideToRight(seconds, distanceToSlide == 0 ? element.ActualWidth : distanceToSlide, keepMargin: keepMargin);
                    break;
                case AnimationSlideOutDirection.Top:
                    //Add a slide to bottom animation
                    sb.AddSlideToTop(seconds, distanceToSlide == 0 ? element.ActualWidth : distanceToSlide, keepMargin: keepMargin);
                   break;
                case AnimationSlideOutDirection.Bottom:
                    //Add a slide to bottom animation
                    sb.AddSlideToBottom(seconds, distanceToSlide == 0 ? element.ActualWidth : distanceToSlide, keepMargin: keepMargin);
                    break;
            }

             //Adds a slide from right animation
            sb.AddFadeOut(seconds);

            //Start the animation
            sb.Begin(element);

            //Make the page visible
             element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);

         //  element.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Fade In / Out Animations

        /// <summary>
        /// Animation to fade in
        /// </summary>
        /// <param name="element">Element to animate</param>
        /// <param name="seconds">Duration of the animation in seconds</param>
        /// <returns>Task for Continuation work</returns>
        public static async Task FadeInAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //Create a storyboard
            var sb = new Storyboard();


            //Adds a slide from botttom animation
            sb.AddFadeIn(seconds);

            //Start the animation
            sb.Begin(element);

            //Make the page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Fades Out Animation
        /// </summary>
        /// <param name="element">Element to animate</param>
        /// <param name="seconds">Duration of the naimation in seconds</param>
        /// <returns>Task for Continuation work</returns>
        public static async Task FadeOutAsync(this FrameworkElement element, float seconds = 0.3f)
        {
            //Create a storyboard
            var sb = new Storyboard();

            //Adds a slide to bottom animation
            sb.AddFadeOut(seconds);

            //Start the animation
            sb.Begin(element);

            //Make the page visible
            element.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);

            //Fully hide the element
            element.Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}
