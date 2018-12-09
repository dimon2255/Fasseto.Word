using Fasseto.Word.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Fasseto.Word
{
    /// <summary>
    /// The base class for any content used inside a dialog window
    /// </summary>
    public class BaseDialogUserControl : UserControl
    {
        #region Private Properties

        private DialogWindow mDialogWindow;

        #endregion

        #region Public Properties

        /// <summary>
        /// Minimum width of the dialog
        /// </summary>
        public int WindowMinimuWidth { get; set; } = 250;

        /// <summary>
        /// Minimum height of the dialog
        /// </summary>
        public int WindowMinimuHeight { get; set; } = 100 ;

        /// <summary>
        /// Title height of the dialog
        /// </summary>
        public int TitleHeight { get; set; } = 30;

        public string Title { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Close Command for the Dialog Box
        /// </summary>
        public ICommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                //Create a dialog and set its DataContext
                mDialogWindow = new DialogWindow();
                mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);
            }

            //Set up a close command
            CloseCommand = new RelayCommand(() =>
            {
                mDialogWindow.Close();
            });

        }

        #endregion

        #region Public Dialog Show Methods

        /// <summary>
        /// IUIManager implementation
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public Task ShowDialog<T>(T viewModel)
                                    where T: BaseDialogViewModel
        {
            var tcs = new TaskCompletionSource<bool>();

            IoC.Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    //Try getting title, if error do nothing
                    try
                    {

                        //Match controls expected sizes and messages with title
                        mDialogWindow.ViewModel.WindowMinimumHeight = WindowMinimuHeight;
                        mDialogWindow.ViewModel.WindowMinimumWidth = WindowMinimuWidth;

                        mDialogWindow.ViewModel.TitleHeight = TitleHeight;
                        mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title) ? Title : viewModel.Title;

                        mDialogWindow.Content = this;

                        //Set thr DataContext to its ViewModel
                        DataContext = viewModel;

                        //Show dialog at the center of the parent
                        mDialogWindow.Owner = Application.Current.MainWindow;
                        mDialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;

                        //Show the Dialog
                        mDialogWindow.ShowDialog();
                    }
                    finally
                    {
                        //Let caller know we're finished
                        tcs.TrySetResult(true);
                    }
                });
            });

            return tcs.Task;
        }

        #endregion
    }
}
