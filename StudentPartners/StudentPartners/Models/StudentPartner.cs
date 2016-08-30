using AppServiceHelpers.Models;
using Newtonsoft.Json;

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

		[JsonIgnore]
		public string Name
		{
			get { return $"{FirstName} {LastName}"; }
		}
    }
}
