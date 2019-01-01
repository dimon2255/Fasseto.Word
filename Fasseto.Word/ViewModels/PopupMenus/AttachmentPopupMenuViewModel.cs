
using Fasseto.Word.Core;

namespace Fasseto.Word
{
    /// <summary>
    /// View Model for Bubble Content
    /// </summary>
    public class AttachmentPopupMenuViewModel : BaseViewModel
    {

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AttachmentPopupMenuViewModel()
        {
            //Subscribe to the event
            GlobalEventLocator.ToggleAttachMenuEvent.Subscribe(ToggleAttachmentMenuVisibilty);
        }

        /// <summary>
        /// Method that this ViewModel executes when it is notified other VMs
        /// </summary>
        /// <param name="visibilty"></param>
        private void ToggleAttachmentMenuVisibilty(bool visibilty)
        {
            //toggle the visibility of attach content bubble
            AttachmentMenuVisible = visibilty;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Indicates whether bubble content visible or not
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        #endregion
    }
}
