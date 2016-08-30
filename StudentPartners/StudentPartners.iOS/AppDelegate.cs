using Foundation;
using UIKit;

using HockeyApp.iOS;

namespace StudentPartners.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
		const string HOCKEYAPP_ID = "e3af674e9107494d91917910ac301eed";
		const string INSIGHTS_ID = "7192b141f99a9ac22d0dfd02ac5e114f56cbeb08";

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			Xamarin.Insights.Initialize(INSIGHTS_ID);

			var manager = BITHockeyManager.SharedHockeyManager;
			manager.Configure(HOCKEYAPP_ID);
			manager.DisableUpdateManager = true;
			manager.StartManager();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
