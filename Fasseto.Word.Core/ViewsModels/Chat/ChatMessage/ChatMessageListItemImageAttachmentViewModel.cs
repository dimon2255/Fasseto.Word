using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// A View model for each list item image attachment in the overview chat thread
    /// </summary>
    public class ChatMessageListItemImageAttachmentViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// the tumbnail url
        /// </summary>
        private string mThumbnailUrl;

        #endregion

        #region Public Members

        /// <summary>
        /// The title of the image
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Size of the file
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// Original Filename
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ThumbnailUrl
        {
            get => mThumbnailUrl;
            set
            {
                if (value == mThumbnailUrl)
                    return;

                mThumbnailUrl = value;

                //TODO: Download image from website]
                //      Save file to local storage/cache
                //      Set LocalFilePath value

                Task.Delay(2000).ContinueWith(task =>
                {
                    LocalFilePath = "/Images/Samples/above-moscow.jpg";
                });
            }
        }

        /// <summary>
        /// The local file path on this machine to the downloaded file
        /// </summary>
        public string LocalFilePath { get; set; }

        /// <summary>
        /// Indicates whether Image was loaded or not
        /// </summary>
        public bool ImageLoaded => LocalFilePath != null;

        #endregion

    }
}
