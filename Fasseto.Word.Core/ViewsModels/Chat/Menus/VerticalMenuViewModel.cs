using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Menu ViewModel that contains MenuItems
    /// </summary>
    public class VerticalMenuViewModel : BaseViewModel
    {
         /// <summary>
        /// List of MenuItems
        /// </summary>
        public List<VerticalMenuItemViewModel> MenuItems { get; set; }

    }
}
