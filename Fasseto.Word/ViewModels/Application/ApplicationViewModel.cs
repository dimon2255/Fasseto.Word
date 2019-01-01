using Dna;
using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    public class ApplicationViewModel : BaseViewModel
    {
        #region Private Properties

        /// <summary>
        /// Indicates whether the settings menu should be visible or not.
        /// </summary>
        private bool mSettingMenuVisible;

        #endregion

        #region Transactional Properties

        /// <summary>
        /// Indicates if the user is currently being logged in
        /// </summary>
        public bool LoggingIn { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// Determines whether the server is reachable or not
        /// </summary>
        public bool ServerReachable{ get; set; }

        /// <summary>
        /// Indicates whether the side menu should be visible or not.
        /// </summary>
        public bool SideMenuVisible { get; set; }

        /// <summary>
        /// Indicates whether the settings menu should be visible or not.
        /// </summary>
        public bool SettingsMenuVisible
        {
            get => mSettingMenuVisible;
            set
            {
                if (mSettingMenuVisible == value)
                    return;

                mSettingMenuVisible = value;

                if (mSettingMenuVisible)
                    CoreDI.TaskManager.RunAndForget(ViewModelSettings.LoadAsync);
            }
        }

        /// <summary>
        /// Current Page of the Application.
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// The current page View Model to use when GoToPage is called
        /// </summary>
        public BaseViewModel CurrentPageViewModel { get; set; }

        /// <summary>
        /// Determines the current side menu content
        /// </summary>
        public SideMenuContent CurrentSideMenuContent { get; set; } = SideMenuContent.Chat;

        #endregion

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

        /// <summary>
        /// Handles what happens when we have successfully logged in
        /// </summary>
        /// <param name="loginResult"></param>
        /// <returns></returns>
        public async Task HandleSuccessfulLoginAsync(UserProfileDetailsApiModel loginResult)
        {
            //Lock the command ignore all others, while processing
            await RunCommandAsync(() => LoggingIn, async () =>
            {
                //Store this in client data store
                await ClientDataStore.SaveLoginCredentialsAsync(loginResult.ToLoginCredentialsDataModel());

                //Load setting from the local Data Store
                await ViewModelSettings.LoadAsync();

                //Go to chat page
                ViewModelApplication.GoToPage(ApplicationPage.Chat);
            });
        }
    }
}
