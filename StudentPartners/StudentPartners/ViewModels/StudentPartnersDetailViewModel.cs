using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentPartners.Models;

namespace StudentPartners.ViewModels
{
    public class StudentPartnersDetailViewModel
    {
        public StudentPartner StudentPartner { get; set; }

        public StudentPartnersDetailViewModel(StudentPartner studentPartner)
        {
            StudentPartner = studentPartner;
        }
    }
}
