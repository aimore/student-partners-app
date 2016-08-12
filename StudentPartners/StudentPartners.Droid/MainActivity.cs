using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using HockeyApp.Android;

namespace StudentPartners.Droid
{
    [Activity(Label = "StudentPartners", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const string HOCKEYAPP_ID = "e3af674e9107494d91917910ac301eed";
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            CrashManager.Register(this, HOCKEYAPP_ID);
            Xamarin.Insights.Initialize("7192b141f99a9ac22d0dfd02ac5e114f56cbeb08", this);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            CheckForUpdates();
        }

        protected override void OnPause()
        {
            base.OnPause();

            UnregisterUpdateManager();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterUpdateManager();
        }

        void CheckForUpdates()
        {
            UpdateManager.Register(this, HOCKEYAPP_ID);
        }

        void UnregisterUpdateManager()
        {
            UpdateManager.Unregister();
        }
    }
}