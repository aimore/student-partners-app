using UIKit;

namespace StudentPartners.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            Xamarin.Insights.Initialize("7192b141f99a9ac22d0dfd02ac5e114f56cbeb08");

            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}