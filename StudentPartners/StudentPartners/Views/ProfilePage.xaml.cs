using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StudentPartners.Views
{
    public partial class ProfilePage : ContentPage
    {
		private EditProfilePage _editProfilePage = new EditProfilePage();

        public ProfilePage()
        {
			InitializeComponent();

			this.editProfile.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(_editProfilePage, true);
			};
        }
    }
}
