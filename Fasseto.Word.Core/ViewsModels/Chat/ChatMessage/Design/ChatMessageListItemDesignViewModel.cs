using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatMessageListItemViewModel"/>
    /// </summary>
    public class ChatMessageListItemDesignViewModel : ChatMessageListItemViewModel
    {

        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatMessageListItemDesignViewModel Instance => new ChatMessageListItemDesignViewModel();
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatMessageListItemDesignViewModel()
        {
            SenderName = "Dimitri";
            Message = "This new cha app is awesome! When is it coming out. I want one NOW!";
            Initials = "DP";
            ProfilePictureColorRGB = "3099c5";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract((TimeSpan.FromDays(1.3)));

        }

        #endregion  
    }
}
