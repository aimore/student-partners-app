using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StudentPartners.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        Command loginCommand;
        public Command LoginCommand
        {
            get { return loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync())); }
        }

        async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                // Log the user in!
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ERROR: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}