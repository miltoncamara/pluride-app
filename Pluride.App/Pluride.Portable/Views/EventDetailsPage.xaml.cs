using Pluride.App.Portable.Models;
using Pluride.App.Portable.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pluride.App.Portable.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventDetailsPage : ContentPage
	{
        EventDetailsViewModel vm;

        public EventDetailsPage (Event model = null)
		{
			InitializeComponent();
            MainScroll.ParallaxView = HeaderView;

            BindingContext = vm = new EventDetailsViewModel(model);
		}

        void MainScroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY > (MainStack.Height - SpeakerTitle.Height))
                Title = vm.Event.Name;
            else
                Title = "Informações";
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            //MainStack.HeightRequest = HeaderView.Height;
            MainScroll.Parallax();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainScroll.Scrolled += MainScroll_Scrolled;
            MainScroll.Parallax();

            if (vm.Rides.Count == 0)
                vm.LoadRidesCommand.Execute(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainScroll.Scrolled -= MainScroll_Scrolled;
        }
    }
}