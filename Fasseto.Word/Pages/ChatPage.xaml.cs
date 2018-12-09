using Fasseto.Word.Core;
using System;
using System.Security;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        #region Constructors

        /// <summary>
        /// Default Constructor Constructor
        /// </summary>
        public ChatPage()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Overrloaded Constructor
        /// </summary>
        /// <param name="specificViewModel">ViewModel to use on the Page</param>
        public ChatPage(ChatMessageListViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

        #region Method Overrides

        /// <summary>
        /// Fired when ViewModel changes
        /// </summary>
        protected override void OnViewModelChanged()
        {
            //Make sure UI exists
            if (ChatMessageList == null)
                return;

            //Fade in mesages
            var storyboard = new Storyboard();
            storyboard.AddFadeIn(1);
            storyboard.Begin(ChatMessageList);

            //Make the message nox focused
            MessageText.Focus();
        }

        #endregion
         
        /// <summary>
        /// Preview the input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageText_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //Get the textbox
            var textbox = sender as TextBox;

            //Check if enter is pressed
            if(e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    //Add new line at the point where the cursor is
                    var index = textbox.CaretIndex;

                    //insert new line
                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    //Shift the caret forward
                    textbox.CaretIndex = index + Environment.NewLine.Length;
                }
                else
                {
                    ViewModel.SendCommand();
                }

                e.Handled = true;
            }
        }
    }
}