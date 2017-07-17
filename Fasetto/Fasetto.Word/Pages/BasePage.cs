using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    public class BasePage : Page
    {
        public BasePage()
        {
            if (this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            this.Loaded += this.BasePage_Loaded;
        }        

        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        public float SlideSeconds { get; set; } = 0.8f;

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

        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AnimateIn();
            this.AnimateOut();
        }
    }
}
