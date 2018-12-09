using Fasseto.Word.Core;
using System.Security;

namespace Fasseto.Word
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        /// <summary>
        /// SecurePassword for this login page.
        /// </summary>
        public SecureString SecurePassword =>  PasswordText.SecurePassword;


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginPage(LoginViewModel specificViewModel) : base(specificViewModel)
        {
            InitializeComponent();
        }

        #endregion

    }
}
