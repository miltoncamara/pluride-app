using Pluride.App.Helpers;
using Pluride.App.Portable.Models;
using Pluride.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pluride.App.Portable.ViewModels
{
    public class EventDetailsViewModel : BaseViewModel
    {
        public Event Event { get; set; }
        public ObservableRangeCollection<Ride> Rides { get; set; }
        public Command LoadRidesCommand { get; set; }

        public EventDetailsViewModel(Event model = null)
        {
            Event = model;
            Rides = new ObservableRangeCollection<Ride>();
            LoadRidesCommand = new Command(async () => await ExecuteLoadRidesCommand());
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
