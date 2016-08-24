using StudentPartners.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppServiceHelpers;
using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;
using StudentPartners.Models;
using StudentPartners.Views;

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
                var loginSuccessful = await EasyMobileServiceClient.Current.LoginAsync(MobileServiceAuthenticationProvider.WindowsAzureActiveDirectory);
                if (loginSuccessful)
                {
                    // Fetch additional information about our user.
                    var studentPartner = await EasyMobileServiceClient.Current.MobileService.InvokeApiAsync<StudentPartner>("UserInfo", System.Net.Http.HttpMethod.Get, null);
                    Settings.FirstName = studentPartner.FirstName;
                    Settings.LastName = studentPartner.LastName;
                    Settings.PhotoUrl = studentPartner.PhotoUrl;
                    Settings.StudentPartner = studentPartner;

                    Application.Current.MainPage = new RootPage();
                }
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