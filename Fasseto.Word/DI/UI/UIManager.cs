using Fasseto.Word.Core;
using System.Threading.Tasks;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// Application implementation of the UIManager
    /// </summary>
    public class UIManager : IUIManager
    {
        /// <summary>
        /// IUIManager implementation
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            var tcs = new TaskCompletionSource<bool>();

            try
            {
                Application.Current.Dispatcher.Invoke(async () =>
                {
                    await new DialogMessageBox().ShowDialog(viewModel);
                });
            }
            finally
            {
                tcs.TrySetResult(true);
            }

            return tcs.Task;
        }
    }
}
