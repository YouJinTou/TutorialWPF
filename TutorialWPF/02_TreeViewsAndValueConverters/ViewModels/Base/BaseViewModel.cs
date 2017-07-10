using System.ComponentModel;

namespace _02_TreeViewsAndValueConverters.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (e, sender) => { };
    }
}
