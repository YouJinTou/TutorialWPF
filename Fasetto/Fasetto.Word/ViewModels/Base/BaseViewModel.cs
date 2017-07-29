using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Fasetto.Word
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (e, sender) => { };

        public void OnPropertyChanged(string name)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            if (updatingFlag.GetPropertyValue())
            {
                return;
            }

            updatingFlag.SetPropertyValue(true);
            
            try
            {
                await action();
            }
            finally
            {
                updatingFlag.SetPropertyValue(false);
            }
        }
    }
}
