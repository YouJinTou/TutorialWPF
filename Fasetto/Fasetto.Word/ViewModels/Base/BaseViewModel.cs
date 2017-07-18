using System.ComponentModel;

namespace Fasetto.Word
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (e, sender) => { };

        public void OnPropertyChanged(string name)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
