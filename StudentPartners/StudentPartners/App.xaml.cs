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
		public static StudentPartner User { get; set; }

        public App()
        {
            InitializeComponent();

			EasyMobileServiceClient.Current.Initialize("https://studentpartners.azurewebsites.net/");
			EasyMobileServiceClient.Current.RegisterTable<StudentPartner>();
			EasyMobileServiceClient.Current.FinalizeSchema();

			SetMainPage();
        }

		void SetMainPage()
		{
			MainPage = new LoginPage();
			//if (Settings.IsLoggedIn)
			//{
			//	if (Device.OS != TargetPlatform.iOS)
			//		MainPage = new RootPage();
			//	else
			//		MainPage = new RootPageiOS();
			//}
			//else
			//{
			//	MainPage = new LoginPage();
			//}
		}
    }
}
