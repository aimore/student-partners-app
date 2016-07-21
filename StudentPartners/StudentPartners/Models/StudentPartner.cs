using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPartners.Models
{
    public class StudentPartner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }

        // Address
        public string Country { get; set; }

        public string Name
        {
            get { return $"{FirstName} {LastName}";  }
        }
    }
}
