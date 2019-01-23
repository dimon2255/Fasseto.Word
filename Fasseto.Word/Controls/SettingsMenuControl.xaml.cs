using Fasseto.Word.Core;
using System.ComponentModel;
using System.Windows.Controls;

using static Fasseto.Word.DI;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsMenuControl : UserControl
    {
        public SettingsMenuControl()
        {
            InitializeComponent();

            if (DesignerProperties.GetIsInDesignMode(this))
                DataContext = new SettingsMenuViewModel();
            else
                DataContext = ViewModelSettings;

        }
    }
}
