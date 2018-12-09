using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    public class ApplicationViewModel : BaseViewModel
    {

        /// <summary>
        /// Indicates whether the sidemenu should be visible or not.
        /// </summary>
        public bool SideMenuVisible { get; set; }

        /// <summary>
        /// Indicates whether the settings menu should be visible or not.
        /// </summary>
        public bool SettingsMenuVisible { get; set; }

        /// <summary>
        /// Current Page of the Application.
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// The current page View Model to use when GoToPage is called
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// Navigate to specified page
        /// </summary>
        /// <param name="page"></param>
        /// <param name="viewModel">The view model, if any</param>
        public void GoToPage(ApplicationPage page, BaseViewModel viewModel = null)
        {

            //Set settings menu to invisible
            SettingsMenuVisible = false;

            //Set the current view model
            CurrentPageViewModel = viewModel;

            //Set the current page
            CurrentPage = page;

            //Fire off a current page changed event
            RaisePropertyChanged(nameof(CurrentPage));

            //Show side menu or not
            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
