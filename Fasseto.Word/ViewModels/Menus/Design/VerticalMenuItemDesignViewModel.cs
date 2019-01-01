using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// Menu Item View Model for Design Time
    /// </summary>
    public class VerticalMenuItemDesignViewModel : VerticalMenuItemViewModel
    {
        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static VerticalMenuItemDesignViewModel Instance => new VerticalMenuItemDesignViewModel();
        #endregion


        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public VerticalMenuItemDesignViewModel()
        {
            Text = "Hello World";
            IconType = IconType.File;
        } 

        #endregion
    }
}
