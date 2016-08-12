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
    public partial class StudentPartnersDetailPage : ContentPage
    {
        public StudentPartnersDetailPage(StudentPartner studentPartner)
        {
            InitializeComponent();

            BindingContext = new StudentPartnersDetailViewModel(studentPartner);
        }
    }
}
