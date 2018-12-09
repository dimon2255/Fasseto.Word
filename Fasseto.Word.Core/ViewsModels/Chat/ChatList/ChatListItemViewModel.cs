using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A View model for each chat message list item in the thread
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {
      
        #region Public Members

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

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

        /// <summary>age is available
        /// Indicates whether new content/message
        /// </summary>
        public bool IsNewContentAvailable { get; set; }
      

        /// <summary>
        /// Indicates if the item is currently selected or not.
        /// </summary>
        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Command to open message
        /// </summary>
        public ICommand OpenMessageCommand { get; set; }

        #endregion

        #region Contructor

        /// <summary>
        /// Default Contructor
        /// </summary>
        public ChatListItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Opens a message
        /// </summary>
        private void OpenMessage()
        {

            IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel()
            {
                DisplayTitle = "Dimitri, Me",

                Items = new ObservableCollection<ChatMessageListItemViewModel>()
                      {
                          new ChatMessageListItemViewModel()
                          {
                              Message = Message,
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF00FF",
                              SenderName = "Dimitri",
                              SentByMe = true,
                          },
                          new ChatMessageListItemViewModel()
                          {
                              Message = "A recieved message",
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF0000",
                              SenderName = "Julia",
                              SentByMe = false,
                          },
                           new ChatMessageListItemViewModel()
                          {
                              Message = "A recieved message",
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF00FF",
                              SenderName = "Kiki",
                              SentByMe = false,
                          },

                           new ChatMessageListItemViewModel()
                          {
                              Message = Message,
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF00FF",
                              SenderName = "Dimitri",
                              SentByMe = true,
                          },
                          new ChatMessageListItemViewModel()
                          {
                              Message = "A recieved message, hello world...",
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF0000",
                              SenderName = "Julia",
                              SentByMe = false,
                          },
                           new ChatMessageListItemViewModel()
                          {
                              Message = "A recieved message, hello world...",
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF00FF",
                              SenderName = "Kiki",
                              SentByMe = false,
                          },

                             new ChatMessageListItemViewModel()
                          {
                              Message = Message,
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF00FF",
                              SenderName = "Dimitri",
                              SentByMe = true,
                          },
                          new ChatMessageListItemViewModel()
                          {
                              Message = "A recieved message, hello world...",
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF0000",
                              SenderName = "Julia",
                              SentByMe = false,
                          },
                           new ChatMessageListItemViewModel()
                          {
                              Message = "A recieved message, hello world...",
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF00FF",
                              SenderName = "Kiki",
                              SentByMe = false,
                          },
                           new ChatMessageListItemViewModel()
                          {
                              Message = "A recieved message, hello world...",
                              ImageAttachment = new ChatMessageListItemImageAttachmentViewModel()
                              {
                                  ThumbnailUrl = "http://anywhere.ru",
                              },
                              Initials = Initials,
                              MessageSentTime = DateTimeOffset.UtcNow,
                              ProfilePictureColorRGB = "FF00FF",
                              SenderName = "Kiki",
                              SentByMe = false,
                          },
                      }

            });
        }


        #endregion


    }
}
