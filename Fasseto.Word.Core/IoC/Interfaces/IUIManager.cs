using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasseto.Word.Core
{
    /// <summary>
    /// The UI that handles the UI interaction in the application
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Display as Simple Message ox to the user
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        Task ShowMessage(MessageBoxDialogViewModel viewModel);
    }
}
