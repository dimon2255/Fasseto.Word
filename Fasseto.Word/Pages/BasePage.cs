using Dna;
using Fasseto.Word.Core;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasseto.Word
{

    public class BasePage : UserControl
    {

        #region Private Members

        /// <summary>
        /// ViewModel Associated with this page
        /// </summary>
        private object _viewModel;

        #endregion

        /// <summary>
        /// The animation to play when page first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The animation to play when page is unloaded
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// Time to slide animation slides
        /// </summary>
        public double SlideSeconds { get; set; } = 0.5;

        /// <summary>
        /// A flag to indicate whether the page should be animated out or not.
        /// Useful for when we are using 
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        /// <summary>
        /// ViewModel Associated with this page
        /// </summary>
        public object ViewModelObject
        {
            get
            {
                return this._viewModel;
            }
            set
            {
                //Make sure ViewModel has changed
                if (this._viewModel == value)
                    return;

                //Set the value to ViewModel
                this._viewModel = value;

                //Set the DataContext for this Page
                this.DataContext = this._viewModel;

                //Call Children if any
                OnViewModelChanged();
            }
        }


        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BasePage()
        {
            // If in deign mode don't bother doing animation
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            // If we are animating in, hide to begin with
            if (this.PageLoadAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += BasePage_LoadedAsync;

        }

        #endregion

        #region Animation Load/ Unload

        /// <summary>
        /// When the page is loaded do required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ShouldAnimateOut)
                await AnimateOutAsync();
            else
                await AnimateInAsync();
        }


        #endregion


        #region Animation Methods

        /// <summary>
        /// Animates in this page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    //Start the animation and for it to complete
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, 
                                                    true,
                                                    (float)this.SlideSeconds, distanceToSlide 
                                                    : 
                                                    (int)Application.Current.MainWindow.Width);
                    break;
            }
        }


        /// <summary>
        /// Animates out this page
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            if (this.PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    //Start the animation and for it to complete
                    await this.SlideAndFadeOutAsync(AnimationSlideOutDirection.Left, (float)this.SlideSeconds);
                    break;
            }
        }

        #endregion

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected virtual void OnViewModelChanged()
        {

        }
    }

    /// <summary>
    /// A base page for all pages to gain base functionality
    /// </summary>
    public class BasePage<VM> : BasePage
                    where VM : BaseViewModel, new()
    {


        #region Constructor

        /// <summary>
        /// Overloaded Constructor
        /// <paramref name="specificViewModel"/>
        /// </summary>
        public BasePage(VM specificViewModel = null) : base()
        {
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            else
            {
                if (DesignerProperties.GetIsInDesignMode(this))
                {
                    ViewModel = new VM();

                }
                else
                {
                    ViewModel = Framework.Service<VM>() ?? new VM();                
                }
            }
        }


        /// <summary>
        /// Default Constructor
        /// <paramref name="specificViewModel"/>
        /// </summary>
        public BasePage() : base()
        {
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                ViewModel = new VM();

            }
            else
            {
                ViewModel = Framework.Service<VM>() ?? new VM();
            }
        }

        #endregion

        #region Public Properties


        /// <summary>
        /// ViewModel Associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

    }
}
