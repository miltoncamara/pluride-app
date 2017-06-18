using Pluride.App.Portable.Helpers;
using Pluride.App.Portable.Models;
using Pluride.App.Portable.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pluride.App.Portable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RidePage : ContentPage
	{
        RideViewModel vm;

        public RidePage ()
		{
			InitializeComponent ();

            BindingContext = vm = new RideViewModel();
		}

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Ride;
            if (item == null)
                return;

            await NavigationHelper.PushAsync(Navigation, new RideDetailsPage(item));

            ListViewEvents.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(vm.Rides.Count == 0)
                vm.LoadRidesCommand.Execute(0);
        }
    }
}