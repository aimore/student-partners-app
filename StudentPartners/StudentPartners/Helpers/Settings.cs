using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppServiceHelpers;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using StudentPartners.Models;

namespace StudentPartners.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static StudentPartner StudentPartner { get; set; }

        #region Setting Constants
        private const string LoggedInKey = "logged_in";

        public const string FirstNameKey = "first_name";
        private static readonly string FirstNameDefault = "Pierce";

        public const string LastNameKey = "last_name";
        private static readonly string LastNameDefault = "Boggan";

        public const string PhotoUrlKey = "photo_url";
        private static readonly string PhotoUrlDefault = "https://secure.gravatar.com/avatar/62921d835f6d165597ff0dcd40fd2664?s=260&d=mm&r=g";
        #endregion
        
        public static bool IsLoggedIn => EasyMobileServiceClient.Current.MobileService.CurrentUser.UserId != null;

        public static string FirstName
        {
            get { return AppSettings.GetValueOrDefault<string>(FirstNameKey, FirstNameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(FirstNameKey, value); }
        }

        public static string LastName
        {
            get { return AppSettings.GetValueOrDefault<string>(LastNameKey, LastNameDefault); }
            set { AppSettings.AddOrUpdateValue<string>(LastNameKey, value); }
        }

        public static string PhotoUrl
        {
            get { return AppSettings.GetValueOrDefault<string>(PhotoUrlKey, PhotoUrlDefault); }
            set { AppSettings.AddOrUpdateValue<string>(PhotoUrlKey, value); }
        }
    }
}