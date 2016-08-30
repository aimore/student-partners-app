using System;
using System.Collections.Generic;

using StudentPartners.ViewModels;
using Xamarin.Forms;

namespace StudentPartners
{
	public partial class EditProfilePage : ContentPage
	{
		public EditProfilePage()
		{
			InitializeComponent();

			BindingContext = new EditPageViewModel();
		}
	}
}

