using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Type of the menu item
    /// </summary>
    public enum MenuItemType
    {
        /// <summary>
        /// None
        /// </summary>
        None = 0,

        /// <summary>
        /// Shows the menu text and icon
        /// </summary>
        TextAndIcon = 1,

        /// <summary> Seperation line
        /// </summary>
        Divider = 2,

        /// <summary>
        /// Header Menu Item
        /// </summary>
        Header = 3
    }
}