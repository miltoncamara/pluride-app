using Pluride.App.Helpers;
using Pluride.App.Portable.Helpers;
using Pluride.App.Portable.Models;
using Pluride.App.Portable.Views;
using Pluride.App.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pluride.App.Portable.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Event> Events { get; set; }
        public Command LoadEventsCommand { get; set; }

        public HomeViewModel()
        {
            Events = new ObservableRangeCollection<Event>();
            LoadEventsCommand = new Command(async () => await ExecuteLoadEventsCommand());
        }

        private async Task ExecuteLoadEventsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Events.Clear();
                var table = App.CloudService.GetTable<Event>();
                var list = await table.ReadAllItemsAsync();
                Events.ReplaceRange(list);
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
