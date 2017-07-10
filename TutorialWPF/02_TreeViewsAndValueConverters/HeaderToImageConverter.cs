using _02_TreeViewsAndValueConverters.Data;
using _02_TreeViewsAndValueConverters.ViewModels;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace _02_TreeViewsAndValueConverters
{
    [ValueConversion(typeof(DirectoryType), typeof(BitmapImage))]
    class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var image = "Images/file.png";

            switch ((DirectoryType)value)
            {
                case DirectoryType.Drive:
                    image = "Images/drive.png";

                    break;
                case DirectoryType.Folder:
                    image = "Images/folder-closed.png";

                    break;
                default:
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
