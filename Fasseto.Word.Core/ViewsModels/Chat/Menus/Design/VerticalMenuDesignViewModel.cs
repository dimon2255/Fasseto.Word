
using System.Collections.Generic;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// Menu Design View Model
    /// </summary>
    public class VerticalMenuDesignViewModel : VerticalMenuViewModel
    {

        #region Singleton
        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static VerticalMenuDesignViewModel Instance => new VerticalMenuDesignViewModel();
        #endregion



        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public VerticalMenuDesignViewModel()
        {
            MenuItems = new List<VerticalMenuItemViewModel>()
            {
                new VerticalMenuItemViewModel()
                {
                    MenuItemType = MenuItemType.Header,
                    Text = "Attach file ...",
                },
                new VerticalMenuItemViewModel()
                {
                    IconType = IconType.File,
                    Text = "From Computer",
                    MenuItemType = MenuItemType.TextAndIcon
                },
                new VerticalMenuItemViewModel()
                {
                    IconType = IconType.Picture,
                    Text = "From Pictures",
                    MenuItemType = MenuItemType.TextAndIcon
                },


            };
        }

        #endregion
    }
}
