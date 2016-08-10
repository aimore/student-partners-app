using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPartners.ViewModels
{
    public class MenuPageViewModel : BaseViewModel
    {
        public MenuPageViewModel()
        {
            ProfilePhotoUrl = "https://avatars3.githubusercontent.com/u/1091304?v=3&s=460";
        }

        string profilePhotoUrl;
        public string ProfilePhotoUrl
        {
            get { return profilePhotoUrl; }
            set { profilePhotoUrl = value; OnPropertyChanged("ProfilePhotoUrl"); }
        }
    }
}
