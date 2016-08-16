using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StudentPartners.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudentPartners.Helpers;
using AppServiceHelpers;
using StudentPartners.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace StudentPartners
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*
            if (Settings.IsLoggedIn)
                MainPage = new RootPage();
            else
                MainPage = new LoginPage();*/
              
            try
            {
                EasyMobileServiceClient.Current.Initialize("https://studentpartners.azurewebsites.net/");
                EasyMobileServiceClient.Current.RegisterTable<StudentPartner>();
                EasyMobileServiceClient.Current.FinalizeSchema();
            }
            catch (Exception ex)
            {
                var x = DateTime.Now;
            }

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
