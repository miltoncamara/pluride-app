using Pluride.App.Portable.Controls;
using Xamarin.Forms;

namespace Pluride.App.Portable.Views.iOS
{
    public class RootPageiOS : TabbedPage
    {
        public RootPageiOS()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Children.Add(new MainNavigationPage(new HomePage()));
            Children.Add(new MainNavigationPage(new RidePage()));
            Children.Add(new MainNavigationPage(new SettingsPage()));
        }
    }
}
