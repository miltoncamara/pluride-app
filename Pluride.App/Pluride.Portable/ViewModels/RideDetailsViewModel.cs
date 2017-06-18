using Pluride.App.Portable.Models;
using Pluride.App.ViewModels;

namespace Pluride.App.Portable.ViewModels
{
    public class RideDetailsViewModel : BaseViewModel
    {
        public Ride Ride { get; set; }

        public RideDetailsViewModel(Ride ride)
        {
            Ride = ride;
        }
    }
}
