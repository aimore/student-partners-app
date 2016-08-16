using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppServiceHelpers.Models;

namespace StudentPartners.Models
{
    public class StudentPartner : EntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Biography { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }

        public string Name
        {
            get { return $"{FirstName} {LastName}";  }
        }
    }
}
