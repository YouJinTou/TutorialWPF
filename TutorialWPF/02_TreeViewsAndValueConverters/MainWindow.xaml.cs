using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace _02_TreeViewsAndValueConverters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive
                };

                item.Items.Add(null);

                item.Expanded += Folder_Expanded;

                this.FolderView.Items.Add(item);
            }
        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            var isDummy = (item.Items.Count != 1 || item.Items[0] != null);

            if (isDummy)
            {
                return;
            }

            item.Items.Clear();

            var fullPath = item.Tag.ToString();
            var dirs = new List<string>();

            try
            {
                dirs.AddRange(Directory.GetDirectories(fullPath));
            }
            catch
            {
            }

            dirs.ForEach(dp =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(dp),
                    Tag = dp
                };

                subItem.Items.Add(null);

                subItem.Expanded += Folder_Expanded;

                item.Items.Add(subItem);
            });

            var files = new List<string>();

            try
            {
                files.AddRange(Directory.GetFiles(fullPath));
            }
            catch
            {
            }

            files.ForEach(fp =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(fp),
                    Tag = fp
                };

                item.Items.Add(subItem);
            });
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            var normalizedPath = path.Replace('/', '\\');
            var lastSlashIndex = normalizedPath.LastIndexOf('\\');

            if (lastSlashIndex <= 0)
            {
                return path;
            }

            return normalizedPath.Substring(lastSlashIndex + 1);
        }
    }
}
