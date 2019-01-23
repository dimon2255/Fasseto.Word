using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fasseto.Word
{
    /// <summary>
    /// The design-time data for a <see cref="ChatMessageListViewModel"/>
    /// </summary>
    public class ChatMessageListDesignViewModel : ChatMessageListViewModel
    {

        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatMessageListDesignViewModel Instance => new ChatMessageListDesignViewModel();
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatMessageListDesignViewModel()
        {
            DisplayTitle = "Dimitri";

            Items = new ObservableCollection<ChatMessageListItemViewModel>()
            {
                new ChatMessageListItemViewModel()
                {
                    SenderName = "Dimitri",
                    Message = "I'm about to wipe the old server. We need to update the old server to Windows 2016",
                    Initials = "DP",
                    ProfilePictureColorRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = true,
                },
                new ChatMessageListItemViewModel()
                {
                    SenderName = "Julia",
                    Message = "Let me know when you manage to spin up the new 2016 server",
                    Initials = "JO",
                    ProfilePictureColorRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = false,
                },
                new ChatMessageListItemViewModel()
                {
                    SenderName = "Dimitri",
                    Message = "The new server is up. Go to 192.168.1.1. Username is admin, password is p8ssw0rd",
                    Initials = "DP",
                    ProfilePictureColorRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = true,
                },

            };
        }

        #endregion  
    }
}
