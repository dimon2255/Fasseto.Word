using Fasseto.Word.Core;
using System.Security;
using System.Windows.Controls;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class RegisterPage: BasePage<RegisterViewModel>, IHavePassword
    {

        #region Public Properties

        /// <summary>
        /// Secured Users password
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;

        #endregion


        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public RegisterPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        public RegisterPage(RegisterViewModel specificViewModel): base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

    }
}
