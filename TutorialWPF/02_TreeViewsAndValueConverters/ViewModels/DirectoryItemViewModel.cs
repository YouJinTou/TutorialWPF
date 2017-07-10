using _02_TreeViewsAndValueConverters.Data;
using _02_TreeViewsAndValueConverters.DirectoryService;
using _02_TreeViewsAndValueConverters.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _02_TreeViewsAndValueConverters.ViewModels
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        public DirectoryItemViewModel(string path, DirectoryType type)
        {
            this.Path = path;
            this.Type = type;
            //this.ExpandCommand = new RelayCommand(this.Expand);

            this.ClearChildren();
        }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        
        public string Name
        {
            get
            {
                return (this.Type == DirectoryType.Drive) ? this.Path : DirService.GetFileFolderName(this.Path);
            }
        }

        public string Path { get; set; }

        public DirectoryType Type { get; set; }

        public ICommand ExpandCommand { get; set; }
        
        public bool IsExpanded
        {
            get
            {
                return (this.Children.Count(c => c != null) > 0);
            }
            set
            {
                if (value)
                {
                    this.Expand();
                }
                else
                {
                    this.ClearChildren();
                }
            }
        }

        private void Expand()
        {
            if (this.Type == DirectoryType.File)
            {
                return;
            }

            var children = DirService.GetDirectoryContents(this.Path);
            this.Children = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(c => new DirectoryItemViewModel(c.Path, c.Type)));
        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();

            if (this.Type != DirectoryType.File)
            {
                this.Children.Add(null);
            }
        }
    }
}
