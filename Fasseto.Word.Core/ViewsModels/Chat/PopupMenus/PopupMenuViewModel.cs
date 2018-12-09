using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    public class PopupMenuViewModel : AttachmentPopupMenuViewModel
    {

        #region Public Properties

        /// <summary>
        /// Background for the bubble
        /// </summary>
        public String BubbleBackground { get; set; }

        /// <summary>
        /// The alignment of the arrow
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }
   

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PopupMenuViewModel()
        {
            //set default values
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }
    }
}
