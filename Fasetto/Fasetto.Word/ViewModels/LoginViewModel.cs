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

        public async Task Login(object parameter)
        {
            await Task.Delay(1000);
        }
    }
}
