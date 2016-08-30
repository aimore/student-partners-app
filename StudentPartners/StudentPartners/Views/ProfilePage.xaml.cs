﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace StudentPartners.Views
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
			InitializeComponent();

			this.editProfile.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(new EditProfilePage(), true);
			};
        }
    }
}
