using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            this.LoginCommand = new RelayParameterizedCommand(async (parameter) => await this.Login(parameter));
        }

        public ICommand LoginCommand { get; set; }

        public string Email { get; set; }

        public bool LoginIsRunning { get; set; }

        public async Task Login(object parameter)
        {
            await this.RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(500);

                var password = (parameter as IHavePassword).SecurePassword.Unsecure();
            });            
        }
    }
}
