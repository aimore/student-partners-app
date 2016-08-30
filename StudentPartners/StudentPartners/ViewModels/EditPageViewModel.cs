using System;
using System.Threading.Tasks;

using AppServiceHelpers;
using StudentPartners.Models;
using Xamarin.Forms;

namespace StudentPartners.ViewModels
{
	public class EditPageViewModel : BaseViewModel
	{
		public StudentPartner User { get; set; }

		public EditPageViewModel()
		{
			this.User = App.User;

			SaveStudentPartnerInformationCommand = new Command(
				async () => await ExecuteSaveStudentPartnerInformationCommandAsync(),
				() => !IsBusy);
		}

		public Command SaveStudentPartnerInformationCommand { get; set; }
		public async Task<bool> ExecuteSaveStudentPartnerInformationCommandAsync()
		{
			return await EasyMobileServiceClient.Current.Table<StudentPartner>().UpdateAsync(App.User);
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Website { get; set; }
		public string Biography { get; set; }

		public string Email { get; set; }
		public string Phone { get; set; }
		public string Gender { get; set; }

		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public string Country { get; set; }
	}
}