using Fasseto.Word.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Attached Property For PageHost class
        /// </summary>
        public ApplicationPage CurrentPage
        {
            get => (ApplicationPage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Registers CurrentPage as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
                                                  DependencyProperty.Register(nameof(CurrentPage),
                                                  typeof(ApplicationPage),
                                                  typeof(PageHost),
                                                  new UIPropertyMetadata(default(ApplicationPage), null, 
                                                      new CoerceValueCallback(CurrentPagePropertyChanged)));


        /// <summary>
        /// Attached Property For PageHost class
        /// </summary>
        public BaseViewModel CurrentPageViewModel
        {
            get => (BaseViewModel)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        /// <summary>
        /// Registers CurrentViewModel as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageViewModelProperty =
                                                  DependencyProperty.Register(nameof(CurrentPageViewModel),
                                                  typeof(BaseViewModel),
                                                  typeof(PageHost),
                                                  new UIPropertyMetadata());


        #endregion

        #region Property Changed Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d
                                                                        , object value)
        {
            //Get current values;
            var currentPage = (ApplicationPage)d.GetValue(CurrentPageProperty);
            var currentPageViewModel = d.GetValue(CurrentPageViewModelProperty);
            
            // Get Frames
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //If current page doesn't change, just update the ViewModel
            if (newPageFrame.Content is BasePage page &&
                       page.ToApplicationPage() == currentPage)
            {
                //Just update the viewmodel
                page.ViewModelObject = currentPageViewModel;
                return value;
            }

            //Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            //Remove current page from new page
            newPageFrame.Content = null;

            //Move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            //Set the flag to indicate that the page needs to animate out.
            if (oldPageContent is BasePage oldpage)
            {
                //tell old page to animate out
                oldpage.ShouldAnimateOut = true;

                //Once it is complete, remove it
                Task.Delay((int)(oldpage.SlideSeconds * 1000)).ContinueWith(task =>
                {
                    //Jump on to the UI thread
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        oldPageFrame.Content = null;
                    });
                });
            }

            //set the new page 
            newPageFrame.Content = currentPage.ToBasePage(currentPageViewModel);

            return value;
        }

        
        #endregion


        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            //if we in design mode, show the current page
            // as the dependency property does not fire
            if (DesignerProperties.GetIsInDesignMode(this))
                NewPage.Content = new ApplicationViewModel().CurrentPage.ToBasePage();

        } 

        #endregion
    }
}
