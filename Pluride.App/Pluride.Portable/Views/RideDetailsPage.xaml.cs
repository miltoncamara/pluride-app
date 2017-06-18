using Pluride.App.Portable.Models;
using Pluride.App.Portable.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pluride.App.Portable.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RideDetailsPage : ContentPage
	{
        RideDetailsViewModel vm;

		public RideDetailsPage (Ride ride)
		{
			InitializeComponent ();
            MainScroll.ParallaxView = HeaderView;

            BindingContext = vm = new RideDetailsViewModel(ride);
		}

        void MainScroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (e.ScrollY > (MainStack.Height - SpeakerTitle.Height))
                Title = vm.Ride.User.Name;
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
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainScroll.Scrolled -= MainScroll_Scrolled;
        }
    }
}