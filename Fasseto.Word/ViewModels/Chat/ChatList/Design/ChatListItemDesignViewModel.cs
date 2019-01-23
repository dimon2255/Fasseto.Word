namespace Fasseto.Word
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignViewModel : ChatListItemViewModel
    {

        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListItemDesignViewModel Instance => new ChatListItemDesignViewModel();
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatListItemDesignViewModel()
        {
            this.Name = "Dimitri";
            this.Initials = "DP";
            this.Message = "The new chat app is awesome! I bet it will be fast too";
            this.ProfilePictureColorRGB = "3039c5";
        }

        #endregion  
    }
}
