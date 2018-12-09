using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// Enum For Sliding In
    /// </summary>
    public enum AnimationSlideInDirection
    {
        /// <summary>
        /// No Direction
        /// </summary>
        None = 0,

        /// <summary>
        /// Slide In Left 
        /// </summary>
        Left = 1,

        /// <summary>
        /// Slide In Right
        /// </summary>
        Right = 2,

        /// <summary>
        /// Slide In To Top
        /// </summary>
        Top = 3,

        /// <summary>
        /// Slide In to Bottom
        /// </summary>
        Bottom = 4

    }

    /// <summary>
    /// Enum For Sliding Out
    /// </summary>
    public enum AnimationSlideOutDirection
    {
        /// <summary>
        /// No Direction
        /// </summary>
        None = 0,

        /// <summary>
        /// Slide Out Left 
        /// </summary>
        Left = 1,

        /// <summary>
        /// Slide Out Right
        /// </summary>
        Right = 2,

        /// <summary>
        /// Slide Out To Top
        /// </summary>
        Top = 3,

        /// <summary>
        /// Slide Out to Bottom
        /// </summary>
        Bottom = 4

    }
}
