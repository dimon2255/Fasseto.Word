using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// Styles of page animation for appearing/disappearing
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// The page slides and fades from the right
        /// </summary>
        SlideAndFadeInFromRight = 1,

        /// <summary>
        /// The page slides and fades out to the left
        /// </summary>
        SlideAndFadeOutToLeft = 2,

        /// <summary>
        /// No fading/sliding
        /// </summary>
        None = 3
    }
}
