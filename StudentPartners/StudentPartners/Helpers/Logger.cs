using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPartners.Helpers
{
    public class Logger
    {
        public static void Identify(string userId)
        {
            Xamarin.Insights.Identify(userId);
        }

        public static void Identify(string userId, Dictionary<string, string> additionalInformation)
        {
            Xamarin.Insights.Identify(userId, additionalInformation);
        }

        public static void TrackEvent(string eventName)
        {
            Xamarin.Insights.Track(eventName);
        }

        public static void TrackEvent(string eventName, Dictionary<string, string> additionalInformation)
        {
            Xamarin.Insights.Track(eventName, additionalInformation);
        }

        public static void Report(Exception ex)
        {
            Xamarin.Insights.Report(ex);
        }

        public static void Report(Exception ex, Dictionary<string, string> additionalInformation)
        {
            Xamarin.Insights.Report(ex, additionalInformation);
        }
    }
}