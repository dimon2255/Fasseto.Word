using Fasseto.Word.Core;
using System;
using System.Diagnostics;
using System.Windows;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for TextEntryControl.xaml
    /// </summary>
    public partial class TextEntryControl : UserControlBase<TextEntryViewModel>
    {

        #region Dependency Properties

        /// <summary>
        /// The label width of a control
        /// </summary>
        public GridLength LabelLength
        {
            get => (GridLength)GetValue(LabelLengthProperty); 
            set => SetValue(LabelLengthProperty, value); 
        }

        // Using a DependencyProperty as the backing store for LabelLength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelLengthProperty =
                                                DependencyProperty.Register("LabelLength", typeof(GridLength), 
                                                typeof(TextEntryControl), 
                                                new PropertyMetadata(GridLength.Auto, 
                                                LabelWidthChanged));

        #endregion


        #region Dependency Callbacks

        /// <summary>
        /// Callback function when dependency property has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void LabelWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                //Set the column definition length to the new value
                (d as TextEntryControl).LabelColumnDefinition.Width = (GridLength)e.NewValue;
            }
            catch(Exception)
            {
                //Make the developer aware of potential issue
                Debugger.Break();

                (d as TextEntryControl).LabelColumnDefinition.Width = GridLength.Auto;
            }
        }


        #endregion



        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TextEntryControl()
        {
            InitializeComponent();
        }

        #endregion

    }
}
