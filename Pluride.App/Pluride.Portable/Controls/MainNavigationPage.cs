using Xamarin.Forms;

namespace Pluride.App.Portable.Controls
{
    public class MainNavigationPage : NavigationPage
    {
        public MainNavigationPage()
        {
            Init();
        }

        public MainNavigationPage(Page root) : base(root)
		{
            Init();
            Title = root.Title;
            Icon = root.Icon;
        }

        void Init()
        {
            BarBackgroundColor = (Color)Application.Current.Resources["Primary"];
            BarTextColor = Color.White;
        }
    }
}
