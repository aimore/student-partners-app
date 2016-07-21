using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentPartners.Models;
using System.Collections.ObjectModel;

namespace StudentPartners.ViewModels
{
    public class StudentPartnersViewModel : BaseViewModel
    {
        public ObservableCollection<StudentPartner> StudentPartners { get; set; }

        public StudentPartnersViewModel()
        {
            StudentPartners = new ObservableCollection<StudentPartner>()
            {
                new StudentPartner { FirstName = "Nat", LastName = "Friedman", Country = "United States of America", PhotoUrl = "http://static4.businessinsider.com/image/559d359decad04574c42a3c4-480/xamarin-nat-friedman.jpg" },
                new StudentPartner { FirstName = "Miguel", LastName = "de Icaza", Country = "Germany", PhotoUrl = "http://images.techhive.com/images/idge/imported/article/nww/2011/03/031111-deicaza-100272676-orig.jpg" },
                new StudentPartner { FirstName = "Joseph", LastName = "Hill", Country = "Canada", PhotoUrl = "https://www.gravatar.com/avatar/f763ec6935726b7f7715808828e52223.jpg?s=256" },
                new StudentPartner { FirstName = "James", LastName = "Montemagno", Country = "Netherlands", PhotoUrl = "http://www.gravatar.com/avatar/7d1f32b86a6076963e7beab73dddf7ca?s=256" },
                new StudentPartner { FirstName = "Pierce", LastName = "Boggan", Country = "Denmark", PhotoUrl = "https://avatars3.githubusercontent.com/u/1091304?v=3&s=460" },
            };
        }
    }
}
