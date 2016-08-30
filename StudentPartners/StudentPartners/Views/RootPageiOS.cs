using System;

using StudentPartners.Views;

using Xamarin.Forms;

namespace StudentPartners
{
	public class RootPageiOS : TabbedPage
	{
		public RootPageiOS()
		{
			Children.Add(new NavigationPage(new StudentPartnersPage())
			{
				Title = "Student Partners"
			});

			Children.Add(new NavigationPage(new ProfilePage())
			{
				Title = "Profile"
			});
		}
	}
}
