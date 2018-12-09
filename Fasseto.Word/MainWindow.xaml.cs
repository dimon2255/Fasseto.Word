using Fasseto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dialog : Window
    {

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Dialog()
        {
            InitializeComponent();

            DataContext = new WindowViewModel(this);            
        }

        private void AppWindow_Deactivated(object sender, EventArgs e)
        {
            //Show Overlay loose focus
            (DataContext as WindowViewModel).DimmableOverlayVisible = true;
        }

        private void AppWindow_Activated(object sender, EventArgs e)
        {
            //Hide overlay if we are focused
            (DataContext as WindowViewModel).DimmableOverlayVisible = false;
       }
    }
}
