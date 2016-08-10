﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Mobile.Server;

namespace StudentPartners.Service.DataObjects
{
    public class StudentPartner : EntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual Address Address { get; set; }
    }
}
