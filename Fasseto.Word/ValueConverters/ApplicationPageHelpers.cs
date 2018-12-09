using Fasseto.Word.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Fasseto.Word
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApplicationPageHelpers
    {
        /// <summary>
        /// Extension method for ApplicationPage, takes in ViewModel and returns a BasePage binded to ViewModel
        /// </summary>
        /// <param name="page">ApplicationPage</param>
        /// <param name="viewModel">ViewModel if any</param>
        /// <returns></returns>
        public static BasePage ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            //Find and appropriate page
            switch (page)
            {
                case ApplicationPage.Login:
                    return new LoginPage(viewModel as LoginViewModel);

                case ApplicationPage.Chat:
                    return new ChatPage(viewModel as ChatMessageListViewModel);

                case ApplicationPage.Register:
                    return new RegisterPage(viewModel as RegisterViewModel);

                default:
                    Debugger.Break();
                    return null;

            }
        }

        /// <summary>
        /// Converts a <see cref="BasePage"/> to specific <see cref="ApplicationPage"/>
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static ApplicationPage ToApplicationPage(this BasePage page)
        {
            //Convert and find BasePage
            if (page is ChatPage)
                return ApplicationPage.Chat;

            if (page is LoginPage)
                return ApplicationPage.Login;

            if (page is RegisterPage)
                return ApplicationPage.Register;

            Debugger.Break();
            return default(ApplicationPage);
        }
    }
}
