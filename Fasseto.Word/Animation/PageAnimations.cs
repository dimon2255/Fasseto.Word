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
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slides In and Fades In Animation
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float seconds)
        {
            //Create a storyboard
            var sb = new Storyboard();

            //Add a slide from right animation
            sb.AddSlideFromRight(seconds, page.WindowWidth);

            //Adds a slide from right animation
            sb.AddFadeIn(seconds);

            //Start the animation
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            await Task.Delay((int) seconds* 1000);
        }

        /// <summary>
        /// Slides Out and Fades Out Animation
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this Page page, float seconds)
        {
            //Create a storyboard
            var sb = new Storyboard();

            //Add a slide from right animation
            sb.AddSlideToLeft(seconds, page.WindowWidth);

            //Adds a slide from right animation
            sb.AddFadeOut(seconds);

            //Start the animation
            sb.Begin(page);

            //Make the page visible
            page.Visibility = Visibility.Visible;

            await Task.Delay((int)seconds * 1000);
        }

    }
}
