using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentPartners.Models;
using StudentPartners.ViewModels;

using Xamarin.Forms;

namespace StudentPartners.Views
{
    public class RootPage : MasterDetailPage
    {
        Dictionary<MenuType, NavigationPage> Pages { get; set; }

        public RootPage()
        {
            Pages = new Dictionary<MenuType, NavigationPage>();
            Master = new MenuPage(this);

            BindingContext = new BaseViewModel
            {
                Title = "Yammerly"
            };

            NavigateAsync(MenuType.StudentPartners);

            InvalidateMeasure();
        }

        public async Task NavigateAsync(MenuType id)
        {
            Page newPage;

            if (!Pages.ContainsKey(id))
            {
                switch (id)
                {
                    case MenuType.Timeline:
                        Pages.Add(id, new NavigationPage(new TimelinePage()));
                        break;
                    case MenuType.StudentPartners:
                        Pages.Add(id, new NavigationPage(new StudentPartnersPage()));
                        break;
                    case MenuType.Profile:
                        Pages.Add(id, new NavigationPage(new ProfilePage()));
                        break;
                }
            }

            newPage = Pages[id];
            if (newPage == null)
                return;

            Detail = newPage;

            if (Device.Idiom != TargetIdiom.Tablet)
                IsPresented = false;
        }
    }
}
