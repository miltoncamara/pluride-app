using Pluride.App.Portable.Config;
using Pluride.App.Portable.Controls;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pluride.App.Portable.Views.Android
{
    public class RootPageDroid : MasterDetailPage
    {
        Dictionary<int, MainNavigationPage> pages;
        DeepLinkPage page;
        bool isRunning = false;

        public RootPageDroid()
        {
            pages = new Dictionary<int, MainNavigationPage>();
            Master = new MenuPage(this);

            pages.Add(0, new MainNavigationPage(new HomePage()));
            Detail = pages[0];
        }

        public async Task NavigateAsync(int menuId)
        {
            MainNavigationPage newPage = null;
            if (!pages.ContainsKey(menuId))
            {
                //only cache specific pages
                switch (menuId)
                {
                    case (int)AppPage.Home: //Home
                        pages.Add(menuId, new MainNavigationPage(new HomePage()));
                        break;
                    case (int)AppPage.Rides://Rides
                        pages.Add(menuId, new MainNavigationPage(new RidePage()));
                        break;
                    case (int)AppPage.Settings://Rides
                        pages.Add(menuId, new MainNavigationPage(new SettingsPage()));
                        break;
                }
            }

            if (newPage == null)
                newPage = pages[menuId];

            if (newPage == null)
                return;

            if (Detail == newPage)
            {
                await newPage.Navigation.PopToRootAsync();
            }

            Detail = newPage;
        }
    }
}
