using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word
{
    /// <summary>
    /// Represents a MenuItem
    /// </summary>
    public class VerticalMenuItemViewModel : BaseViewModel
    {

        /// <summary>
        /// Type of Icon
        /// </summary>
        public IconType IconType { get; set; }

        /// <summary>
        /// Name of enum item
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// MenuItem Type
        /// </summary>
        public MenuItemType MenuItemType { get; set; }

    }
}
