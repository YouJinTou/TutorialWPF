using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    public class BasePage<VM> : Page where VM : BaseViewModel, new()
    {
        private VM viewModel;

        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            this.Loaded += this.BasePage_Loaded;

            this.ViewModel = new VM();
        }        

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.8f;

        public VM ViewModel
        {
            get
            {
                return this.viewModel;
            }
            set
            {
                if (this.viewModel == value)
                {
                    return;
                }

                this.viewModel = value;
                this.DataContext = value;
            }
        }

        public async Task AnimateIn()
        {
            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;
                default:
                    break;
            }
        }

        public async Task AnimateOut()
        {
            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);

                    break;
                default:
                    break;
            }
        }

        private async void BasePage_Loaded(object sender, RoutedEventArgs e)
        {
            await this.AnimateIn();
        }
    }
}
