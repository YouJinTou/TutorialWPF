using System.Security;

namespace Fasetto.Word
{
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public SecureString SecurePassword => this.PasswordText.SecurePassword;
    }
}
