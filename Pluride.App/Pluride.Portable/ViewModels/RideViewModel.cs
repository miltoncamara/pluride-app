using Pluride.App.Helpers;
using Pluride.App.Portable.Helpers;
using Pluride.App.Portable.Models;
using Pluride.App.Portable.Models.Extensions;
using Pluride.App.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pluride.App.Portable.ViewModels
{
    public class RideViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Ride> Rides { get; set; }
        public ObservableRangeCollection<Grouping<string, Ride>> RidesGrouped { get; set; }
        public Command LoadRidesCommand { get; set; }
        public Command ForceRefreshCommand { get; set; }

        public RideViewModel()
        {
            Rides = new ObservableRangeCollection<Ride>();
            RidesGrouped = new ObservableRangeCollection<Grouping<string, Ride>>();
            LoadRidesCommand = new Command(async () => await ExecuteLoadRidesCommand());
            ForceRefreshCommand = new Command(async () => await ExecuteLoadRidesCommand());
        }

        private async Task ExecuteLoadRidesCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Rides.Clear();
                var table = App.CloudService.GetTable<Ride>();
                var list = await table.ReadAllItemsAsync();
                Rides.ReplaceRange(list);
                RidesGrouped.ReplaceRange(Rides.GroupByName());
            }
            catch (Exception ex)
            {
                //MessagingCenter.Send(new MessagingCenterAlert
                //{
                //    Title = "Error",
                //    Message = "Unable to load items.",
                //    Cancel = "OK"
                //}, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
