using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        #region Private Properties

        /// <summary>
        /// Dialog Window View Model Instance
        /// </summary>
        private DialogWindowViewModel _dialogWindowViewModel;

        #endregion

        #region Public Properties

        public DialogWindowViewModel ViewModel
        {
            get => _dialogWindowViewModel;
            set
            {
                if (_dialogWindowViewModel != value)
                {
                    // Set the new value
                    _dialogWindowViewModel = value;

                    //Each time ViewModel is Changed, set it the new instance to DataContext
                    DataContext = _dialogWindowViewModel;
                }
            }
        }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DialogWindow()
        {
            InitializeComponent();
        }
    }
}
