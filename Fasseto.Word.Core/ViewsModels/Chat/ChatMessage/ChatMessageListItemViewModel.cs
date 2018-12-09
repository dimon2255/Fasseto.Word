using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A View model for each list item in the overview chat list
    /// </summary>
    public class ChatMessageListItemViewModel : BaseViewModel
    {
        #region Public Members

        /// <summary>
        /// Indicates whether a current chat message was read or not.
        /// </summary>
        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;

        /// <summary>
        /// The time the message was read, or <see cref="DateTimeOffset.MinValue"/> if not read
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }
     
        /// <summary>
        /// The time the message was read, or <see cref="DateTimeOffset.MinValue"/> if not read
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }
       
        /// <summary>
        /// Indicates whether the message was sent be me or others
        /// </summary>
        public bool SentByMe { get; set; }
      
        /// <summary>
        /// Indicates whether the chat item message is selected or not --> true/false
        /// </summary>
        public bool IsSelected { get; set; }
        
        /// <summary>
        /// Name of the user
        /// </summary>
        public string SenderName { get; set; }
      
        /// <summary>
        /// Message of the user
        /// </summary>
        public string Message { get; set; }
       
        /// <summary>
        /// Initials of the user
        /// </summary>
        public string Initials { get; set; }
        
        /// <summary>
        /// Profile Picture Color RGB
        /// </summary>
        public string ProfilePictureColorRGB { get; set; }

        /// <summary>
        /// Tells if the item is new in the collection or not, helps with animation
        /// </summary>
        public bool NewItem { get; set; }

        /// <summary>
        /// The attachment ot the message, if it is of an image type
        /// </summary>
        public ChatMessageListItemImageAttachmentViewModel ImageAttachment { get; set; }

        /// <summary>
        ///  flag indicating whether we have an image
        /// </summary>
        public bool HasMessage  => Message != null;
        
        /// <summary>
        /// flag indicating whether we have an image attachment
        /// </summary>
        public bool HasImageAttachment => ImageAttachment != null;

        #endregion

    }
}
