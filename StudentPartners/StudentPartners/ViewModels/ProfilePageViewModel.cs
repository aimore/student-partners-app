using System;
namespace StudentPartners.ViewModels
{
	public class ProfilePageViewModel : BaseViewModel
	{
		public string Name
		{
			get { return App.User.Name; }
		}

		public string ProfilePhotoUrl
		{
			get { return App.User.PhotoUrl; }
		}

		public string Country
		{
			get { return App.User.Address?.Country ?? "Planet Earth"; }
		}

		public string Biography
		{
			get { return App.User.Biography; }
		}
	}
}
