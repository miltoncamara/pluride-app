
using Pluride.App.Portable.Helpers;
using Pluride.App.Portable.ViewModels;
using Pluride.App.Portable.Views.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pluride.App.Portable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			InitializeComponent();
            BindingContext = new WelcomeViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<WelcomeViewModel>(this, "NAVIGATE_HOME", async (sender) =>
            {
                if (Device.RuntimePlatform == "Android")
                {
                    //Application.Current.MainPage = new RootPageAndroid();
                    //await NavigationService.PushAsync(Navigation, new HomePage(), true);
                }
                else
                {
                    Application.Current.MainPage = new RootPageiOS();
                    await NavigationHelper.PushAsync(Navigation, new HomePage(), true);
                }
            });
        }
    }
}