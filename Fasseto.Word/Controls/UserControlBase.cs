using Fasseto.Word.Core;
using System.Windows.Controls;

namespace Fasseto.Word
{

    public class UserControlBase<VM> : UserControl
                                where VM: BaseViewModel, new()
    {
        /// <summary>
        /// View Model for control
        /// </summary>
        public VM _viewModel;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserControlBase()
        {
            ViewModel = new VM();
        }

        /// <summary>
        /// ViewModel for any derived class usercontrol
        /// </summary>
        public VM ViewModel
        {
            get
            {
                return _viewModel;
            }
            set
            {
                if (_viewModel == value)
                    return;

                _viewModel = value;

                DataContext = _viewModel;
            }
        }
    }
}
