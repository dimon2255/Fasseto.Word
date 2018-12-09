using System.Collections.Generic;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A View model the overvew of the chat list
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {

        #region Public Members

        /// <summary>
        /// Collection of chat view list items
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }
 
        #endregion
    }
}
