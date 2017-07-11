using System.Windows;

namespace Fasetto.Word.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {   
        private Window window;
        private int outerMarginSize;
        private int windowRadius;

        public WindowViewModel(Window window)
        {
            this.window = window;

            this.window.StateChanged += (sender, e) =>
            {
                this.OnPropertyChanged(nameof(this.ResizeBorderThickness));
                this.OnPropertyChanged(nameof(this.OuterMarginSize));
                this.OnPropertyChanged(nameof(this.OuterMarginSizeThickness));
                this.OnPropertyChanged(nameof(this.WindowRadius));
                this.OnPropertyChanged(nameof(this.WindowCornerRadius));
            };
        }

        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(this.ResizeBorder + this.OuterMarginSize);
            }
        }

        public int OuterMarginSize
        {
            get
            {
                return (this.window.WindowState == WindowState.Maximized) ? 0 : this.outerMarginSize;
            }
            set
            {
                this.outerMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness
        {
            get
            {
                return new Thickness(this.OuterMarginSize);
            }
        }

        public int WindowRadius
        {
            get
            {
                return (this.window.WindowState == WindowState.Maximized) ? 0 : this.windowRadius;
            }
            set
            {
                this.windowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius
        {
            get
            {
                return new CornerRadius(this.WindowRadius);
            }
        }

        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLength
        {
            get
            {
                return new GridLength(this.TitleHeight + this.ResizeBorder);
            }
        }
    }
}
