using Fasetto.Word;
using System.Windows;
using System.Windows.Input;

namespace Fasseto.Word
{
    /// <summary>
    /// View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {

        private Window _window;

        /// <summary>
        /// The margin around the window to allow a drop shadow.
        /// </summary>
        private int _outerMargin = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int _windowRadius = 10;

        /// <summary>
        /// Position of the main window
        /// </summary>
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

         #region Public Properties

        /// <summary>
        /// Indicates whether DIMMABLE Overlay should be visible or not
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }


        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder
        {
            get
            {
                return Borderless ? 0 : 4;
            }
        }

        /// <summary>
        /// Returns true if no border found, and false if there is a border
        /// </summary>
        public bool Borderless
        {
            get
            {
                return _window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked;
            }
        }

        /// <summary>
        /// Thickness of the border 
        /// </summary>
        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(this.ResizeBorder + this.OuterMarginSize);
            }
        }

        /// <summary>
        /// Padding of the content in the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// The margin around the window to allow a drop shadow.
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _outerMargin;
            }
            set
            {
                if(_outerMargin != value)
                {
                    _outerMargin = value;
                    RaisePropertyChanged(nameof(OuterMarginSize));
                }
            }
        }

        /// <summary>
        /// Thickness of outer margin around the window to allow a drop shadow.
        /// </summary>
        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(this.OuterMarginSize);
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            }
            set
            {
                if (_windowRadius != value)
                {
                    _windowRadius = value;
                    RaisePropertyChanged(nameof(WindowRadius));
                }
            }
        }

        /// <summary>
        /// The corner radius of the window
        /// </summary>
        public CornerRadius WindowCornerRadius
        {
            get
            {
                return new CornerRadius(_windowRadius);
            }
        }
                
        /// <summary>
        /// Height of the title var of the caption
        /// </summary>
        public int TitleHeight { get; set; } = 42;
        
        /// <summary>
        /// The corner radius of the window
        /// </summary>
        public GridLength TitleHeightGridLength
        {
            get
            {
                return new GridLength(TitleHeight + ResizeBorder);
            }
        }

        /// <summary>
        /// Main Window Minimum Width
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 800;

        /// <summary>   
        /// Main Window Minimum Height
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 500;


        #endregion

        #region Commands
        
        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command for the menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }



        #endregion


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            this._window = window;

            //Listen for Window resizing
            _window.StateChanged += (sender, e) =>
            {
                RaisePropertyChanged(nameof(ResizeBorderThickness));
                RaisePropertyChanged(nameof(OuterMarginSize));
                RaisePropertyChanged(nameof(OuterMarginSizeThickness));
                RaisePropertyChanged(nameof(WindowRadius));
                RaisePropertyChanged(nameof(WindowCornerRadius));
            };

            // Create commands for the window
            this.MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            this.MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            this.CloseCommand = new RelayCommand(() => _window.Close());
            this.MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition()));

            //Fix Window Resize Issue
            var wResizer = new WindowResizer(_window);
            
        }

        #endregion

        #region Private Helpers


        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(_window);
            return new Point(position.X + _window.Left, position.Y + _window.Top);
        }

        #endregion
    }
}
