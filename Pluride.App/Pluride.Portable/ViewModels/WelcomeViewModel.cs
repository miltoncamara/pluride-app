using Pluride.App.Portable.Helpers;
using Pluride.App.Portable.Views;
using Pluride.App.Portable.Views.iOS;
using Pluride.App.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pluride.App.Portable.ViewModels
{
    public class WelcomeViewModel : BaseViewModel
    {
        public WelcomeViewModel()
        {

        }

        Command facebookLoginCommand;
        public Command FacebookLoginCommand => facebookLoginCommand ?? (facebookLoginCommand = new Command(async () => await ExecuteFacebookLoginCommand().ConfigureAwait(false)));

        private async Task ExecuteFacebookLoginCommand()
        {
            if (IsBusy)
                return;
            IsBusy = true;

            try
            {
                MessagingCenter.Send<WelcomeViewModel>(this, "NAVIGATE_HOME");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
