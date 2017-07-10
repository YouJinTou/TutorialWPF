using _02_TreeViewsAndValueConverters.Data;
using _02_TreeViewsAndValueConverters.DirectoryService;
using _02_TreeViewsAndValueConverters.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Linq;

namespace _02_TreeViewsAndValueConverters.ViewModels
{
    public class DirectoryStructureViewModel : BaseViewModel
    {
        public DirectoryStructureViewModel()
        {
            this.Drives = new ObservableCollection<DirectoryItemViewModel>(DirService.GetLogicalDrives()
                .Select(d => new DirectoryItemViewModel(d.Path, DirectoryType.Drive)));
        }

        public ObservableCollection<DirectoryItemViewModel> Drives { get; set; }
    }
}
