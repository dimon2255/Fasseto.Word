﻿
namespace Fasseto.Word
{
    /// <summary>
    /// The design time data for <see cref="AttachmentPopupMenuViewModel"/> View Model
    /// </summary>
    public class AttachmentPopupMenuDesignViewModel : AttachmentPopupMenuViewModel
    {
        #region Singleton

        /// <summary>
        /// Singleton Instance for our Design View Model
        /// </summary>
        public static AttachmentPopupMenuDesignViewModel Instance => new AttachmentPopupMenuDesignViewModel();

        #endregion

        public AttachmentPopupMenuDesignViewModel()
        {
            AttachmentMenuVisible = true;
        }

    }
}
