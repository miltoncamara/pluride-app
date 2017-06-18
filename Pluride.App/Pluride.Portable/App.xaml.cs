using Pluride.App.Interfaces;
using Pluride.App.Portable.Views;
using Pluride.App.Portable.Views.iOS;
using Pluride.App.Services;
using Xamarin.Forms;

namespace Pluride.App.Portable
{
    public partial class App : Application
	{
        private bool firstRun = true;
        public static App current;
        public static ICloudService CloudService { get; set; }

        public App ()
		{
            InitializeComponent();

            current = this;
            CloudService = new AzureCloudService();
            MainPage = new WelcomePage();
		}

        private void SetRootPage()
        {
            try
            {
                if (firstRun || Xamarin.Forms.Device.RuntimePlatform != "iOS")
                    return;

                var mainNav = MainPage as NavigationPage;
                if (mainNav == null)
                    return;

                var rootPage = mainNav.CurrentPage as RootPageiOS;
                if (rootPage == null)
                    return;

                var rootNav = rootPage.CurrentPage as NavigationPage;
                if (rootNav == null)
                    return;
            }
            catch
            {
            }
            finally
            {
                firstRun = false;
            }
        }

        public void SecondOnResume()
        {
            OnResume();
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnResume()
        {
            try
            {
                if (firstRun || Xamarin.Forms.Device.RuntimePlatform != "iOS")
                    return;

                var mainNav = MainPage as NavigationPage;
                if (mainNav == null)
                    return;

                var rootPage = mainNav.CurrentPage as RootPageiOS;
                if (rootPage == null)
                    return;

                var rootNav = rootPage.CurrentPage as NavigationPage;
                if (rootNav == null)
                    return;
            }
            catch
            {
            }
            finally
            {
                firstRun = false;
            }
        }
    }
}