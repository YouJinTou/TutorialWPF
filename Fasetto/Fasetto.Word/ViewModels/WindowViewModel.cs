using Fasetto.Word.Models;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.ViewModels
{
    public class WindowViewModel : BaseViewModel
    {   
        private Window window;
        private int outerMarginSize;
        private int windowRadius;
        private WindowDockPosition dockPosition = WindowDockPosition.Undocked;

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

            this.MinimizeCommand = new RelayCommand(() => this.window.WindowState = WindowState.Minimized);
            this.MaximizeCommand = new RelayCommand(() =>  this.window.WindowState ^= WindowState.Maximized);
            this.CloseCommand = new RelayCommand(() =>  this.window.Close());
            this.MenuCommand = new RelayCommand(() =>  SystemCommands.ShowSystemMenu(this.window, this.GetMousePosition()));

            var resizer = new WindowResizer(this.window);
        }

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand { get; set; }

        public double WidnowMinimumWidth { get; set; } = 400;

        public double WidnowMinimumHeight { get; set; } = 400;

        public bool Borderless
        {
            get
            {
                return (this.window.WindowState == WindowState.Maximized || this.dockPosition == WindowDockPosition.Undocked);
            }
        }

        public int ResizeBorder
        {
            get
            {
                return this.Borderless ? 0 : 6;
            }
        }

        public Thickness ResizeBorderThickness
        {
            get
            {
                return new Thickness(this.ResizeBorder + this.OuterMarginSize);
            }
        }

        public Thickness InnerContentPadding
        {
            get
            {
                return new Thickness(0);
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

        public ApplicationPage CurrentPage { get; set; }

        private Point GetMousePosition()
        {
            var position = Mouse.GetPosition(this.window);

            return new Point(position.X + this.window.Left, position.Y + this.window.Top);
        }
    }
}
