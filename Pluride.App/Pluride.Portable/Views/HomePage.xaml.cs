using Pluride.App.Portable.Helpers;
using Pluride.App.Portable.Models;
using Pluride.App.Portable.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pluride.App.Portable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        HomeViewModel vm;

        public HomePage ()
		{
			InitializeComponent ();

            BindingContext = vm = new HomeViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Event;
            if (item == null)
                return;

            await NavigationHelper.PushAsync(Navigation, new EventDetailsPage(item));

            ListViewEvents.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (vm.Events.Count == 0)
                vm.LoadEventsCommand.Execute(null);
        }
    }
}