using StudentPartners.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppServiceHelpers;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

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
                var result = await EasyMobileServiceClient.Current.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
            }
            catch (Exception ex)
            {
                Logger.Report(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}