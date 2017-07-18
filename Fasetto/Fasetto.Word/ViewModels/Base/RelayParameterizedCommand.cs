using System;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class RelayParameterizedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        private Action<object> action;

        public RelayParameterizedCommand(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}
