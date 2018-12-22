using System.Collections.Generic;

namespace Fasseto.Word
{
    /// <summary>
    /// The design-time data for a <see cref="TextEntryDesignViewModel"/>
    /// </summary>
    public class TextEntryDesignViewModel : TextEntryViewModel
    {

        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TextEntryDesignViewModel Instance => new TextEntryDesignViewModel();
        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextEntryDesignViewModel()
        {
            Label = "Name";
            OriginalText = "Dimitri Pankov";
            EditedText = "Edited :)";
        }

        #endregion  
    }
}
