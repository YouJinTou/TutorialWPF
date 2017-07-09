using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace _02_TreeViewsAndValueConverters
{
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            var path = value.ToString();
            var image = "Images/file.png";
            var name = MainWindow.GetFileFolderName(path);
            var isDrive = string.IsNullOrEmpty(name);
            var isFolder = new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory);

            if (isDrive)
            {
                image = "Images/drive.png";
            }
            else if (isFolder)
            {
                image = "Images/folder-closed.png";
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
