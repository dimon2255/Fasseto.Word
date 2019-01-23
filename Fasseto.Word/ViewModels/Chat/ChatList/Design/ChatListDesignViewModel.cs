using System.Collections.Generic;

namespace Fasseto.Word
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignViewModel : ChatListViewModel
    {

        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListDesignViewModel Instance => new ChatListDesignViewModel();
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListDesignViewModel()
        {

            this.Items = new List<ChatListItemViewModel>()
            {
                new ChatListItemViewModel()
                {
                    Name = "Dimitri",
                    Initials = "DP",
                    Message = "The new chat app is awesome! I bet it will be fast too",
                    ProfilePictureColorRGB = "3099c5",
                    IsNewContentAvailable = true

                },
                new ChatListItemViewModel()
                {
                    Name = "Julia",
                    Initials = "JO",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureColorRGB = "343fc5",
                    IsSelected= true

                },
                new ChatListItemViewModel()
                {
                    Name = "Kiki",
                    Initials = "KP",
                    Message = "Hey dude, here are the new icons",
                    ProfilePictureColorRGB = "fe9155"

                },
                                new ChatListItemViewModel()
                {
                    Name = "Dimitri",
                    Initials = "DP",
                    Message = "The new chat app is awesome! I bet it will be fast too",
                    ProfilePictureColorRGB = "3099c5"

                },
                new ChatListItemViewModel()
                {
                    Name = "Julia",
                    Initials = "JO",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureColorRGB = "343fc5"

                },
                 new ChatListItemViewModel()
                {
                    Name = "Dimitri",
                    Initials = "DP",
                    Message = "The new chat app is awesome! I bet it will be fast too",
                    ProfilePictureColorRGB = "3099c5",
                    IsNewContentAvailable = true

                },
                new ChatListItemViewModel()
                {
                    Name = "Julia",
                    Initials = "JO",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureColorRGB = "343fc5"

                },
                new ChatListItemViewModel()
                {
                    Name = "Kiki",
                    Initials = "KP",
                    Message = "Hey dude, here are the new icons",
                    ProfilePictureColorRGB = "fe9155"

                },
                                new ChatListItemViewModel()
                {
                    Name = "Dimitri",
                    Initials = "DP",
                    Message = "The new chat app is awesome! I bet it will be fast too",
                    ProfilePictureColorRGB = "3099c5"

                },
                new ChatListItemViewModel()
                {
                    Name = "Julia",
                    Initials = "JO",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureColorRGB = "343fc5"

                },
                 new ChatListItemViewModel()
                {
                    Name = "Dimitri",
                    Initials = "DP",
                    Message = "The new chat app is awesome! I bet it will be fast too",
                    ProfilePictureColorRGB = "3099c5",
                    IsNewContentAvailable = true

                },
                new ChatListItemViewModel()
                {
                    Name = "Julia",
                    Initials = "JO",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureColorRGB = "343fc5",
    
                },
                new ChatListItemViewModel()
                {
                    Name = "Kiki",
                    Initials = "KP",
                    Message = "Hey dude, here are the new icons",
                    ProfilePictureColorRGB = "fe9155"

                },
                                new ChatListItemViewModel()
                {
                    Name = "Dimitri",
                    Initials = "DP",
                    Message = "The new chat app is awesome! I bet it will be fast too",
                    ProfilePictureColorRGB = "3099c5"

                },
                new ChatListItemViewModel()
                {
                    Name = "Julia",
                    Initials = "JO",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureColorRGB = "343fc5"

                }
         };
        }

        #endregion  
    }
}
