using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A View model the overvew of the chat message thread
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ChatMessageListViewModel()
        {
            //Create Commands
            AttachButtonCommand = new RelayCommand(AttachmentCommand);
            SendButtonCommand = new RelayCommand(SendCommand);
            SettingsButtonCommand = new RelayCommand(SettingsButton);

            //Search Commands
            SearchCommand = new RelayCommand(Search);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            //Initialize Items Collection
            Items = new ObservableCollection<ChatMessageListItemViewModel>();
 
            ////Subscribe to the event
            GlobalEventLocator.ToggleAttachMenuEvent.Subscribe(ToggleAnyMenuVisibilty);
        }

        #endregion


        #region Protected Properties

        /// <summary>
        /// The last search text in this list
        /// </summary>
        protected string mLastSearchText;

        /// <summary>
        /// The text to search for in the search command
        /// </summary>
        protected string mSearchText;

        /// <summary>
        /// Collection of chat view list items
        /// </summary>
        protected ObservableCollection<ChatMessageListItemViewModel> mItems;

        /// <summary>
        /// Indicating whether the search is Open.
        /// </summary>
        protected bool mSearchIsOpen;

        #endregion

        #region Public Properties

        /// <summary>
        /// Indicates whether bubble content visible or not
        /// </summary>
        public bool AnyMenuVisible { get; set; }

        /// <summary>
        /// Collection of chat view list items
        /// NOTE: Do not call Items.Add to add messages to this list
        ///       as it will make FilteredItems out of sync
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => mItems;
            set
            {
                if (mItems == value)
                    return;

                mItems = value;

                //Update filtered List
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(mItems);
            }
        }

        /// <summary>
        /// Collection of chat view list items, that include any search filtering
        /// </summary>
        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }
       
        /// <summary>
        /// The Text to search th collection for.
        /// </summary>
        public string SearchText
        {
            get => mSearchText;
            set
            {
                if (mSearchText == value)
                    return;

                mSearchText = value;

                //If search text is empty... 
                if (!string.IsNullOrEmpty(SearchText))
                    //Search to restore messages
                    Search();
            }
        }

        /// <summary>
        /// Flag indicating if search dialog is open
        /// </summary>
        public bool SearchIsOpen
        {
            get => mSearchIsOpen;
            set
            {
                if (mSearchIsOpen == value)
                    return;

                mSearchIsOpen = value;

                //if dialog closes
                if (!mSearchIsOpen)
                    //Clear th search
                    SearchText = string.Empty;
            }
        }

        /// <summary>
        /// The Title of chat list
        /// </summary>
        public string DisplayTitle { get; set; }

        /// <summary>
        /// The message text for the current message being written
        /// </summary>
        public string PendingMessageText { get; set; }

        /// <summary>
        /// Indicates whether settings menu should be visible or not
        /// </summary>
        public bool SettingsMenuVisible { get; set; }

        #endregion


        #region Commands

        /// <summary>
        /// We need ths to hide popup menus when user clicks away
        /// </summary>
        public ICommand PopupClickAwayCommand { get; set; }

        /// <summary>
        /// Command for Attach Button
        /// </summary>
        public ICommand AttachButtonCommand { get; set; }

        /// <summary>
        /// Command for Send button
        /// </summary>
        public ICommand SendButtonCommand { get; set; }

        /// <summary>
        /// Indicates whether attachment menu should be visible or not
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// Command for Settings Button
        /// </summary>
        public ICommand SettingsButtonCommand { get; set; }

        /// <summary>
        /// Command for when user wants to search
        /// </summary>
        public ICommand SearchCommand { get; set; }

        /// <summary>
        /// Command for opening search dialog
        /// </summary>
        public ICommand OpenSearchCommand { get; set; }

        /// <summary>
        /// Command for Closing search dialog
        /// </summary>
        public ICommand CloseSearchCommand { get; set; }

        /// <summary>
        /// Command to clear search text
        /// </summary>
        public ICommand ClearSearchCommand { get; set; }

        #endregion


        #region Command Methods

        /// <summary>
        /// Method to execute when attach button is clicked
        /// </summary>
        public void AttachmentCommand()
        {
            //Toggle menu
            AttachmentMenuVisible ^= true;

            //Publish the event
            GlobalEventLocator.ToggleAttachMenuEvent.Publish(AttachmentMenuVisible);
        }

        /// <summary>
        /// Method that this ViewModel executes when it is notofied by other VMs
        /// </summary>
        /// <param name="visibilty"></param>
        public void ToggleAnyMenuVisibilty(bool visibilty)
        {
            //toogle the visibilty of attach content bubble
            AnyMenuVisible = visibilty;
        }

        /// <summary>
        /// Method to execute when settings button is clicked
        /// </summary>
        public void SettingsButton()
        {
            //Toggle menu
            SettingsMenuVisible ^= true;
        }

        /// <summary>
        /// Method executes when the user clicks Send Button
        /// </summary>
        public void SendCommand()
        {
            //Don't send blank message
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            var message = new ChatMessageListItemViewModel()
            {
                Initials = "DP",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SenderName = "Dimitri Pankov",
                SentByMe = true,
                NewItem = true
            };

            //Add message to both collections
            Items.Add(message);
            FilteredItems.Add(message);

            PendingMessageText = string.Empty;
        }

        /// <summary>
        /// Searches the current message list and filters the view
        /// </summary>
        public void Search()
        {
            //Make sure we don't search for the same text
            if ((string.IsNullOrEmpty(mLastSearchText) && string.IsNullOrEmpty(mSearchText) ||
                            string.Equals(mLastSearchText, mSearchText)))
                return;

            //If we have no search text, or no Items
            if(string.IsNullOrEmpty(SearchText) || Items == null || Items.Count <= 0)
            {
                //Make Filtered List the same
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items);

                mLastSearchText = mSearchText;

                return;
            }

            //Find all Items that contain the given text
            //TODO: Make more efficient search
            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(
                                        Items.Where(item => item.Message.ToLower().Contains(SearchText)));

            //Set last search
            mLastSearchText = SearchText;
        }

        /// <summary>
        /// Clears the Search Text
        /// </summary>
        public void ClearSearch()
        {
            //If there is some search text
            if (!string.IsNullOrEmpty(SearchText))
                SearchText = string.Empty;
            else
                SearchIsOpen = false;                   
        }

        /// <summary>
        /// Open the search dialog
        /// </summary>
        public void OpenSearch() => SearchIsOpen = true;


        /// <summary>
        /// Open the search dialog
        /// </summary>
        public void CloseSearch() => SearchIsOpen = false;

        #endregion
    }
}
