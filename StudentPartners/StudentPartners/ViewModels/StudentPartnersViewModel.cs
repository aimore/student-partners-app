using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentPartners.Models;

using Xamarin.Forms;
using StudentPartners.Helpers;
using StudentPartners.Views;

using AppServiceHelpers;

namespace StudentPartners.ViewModels
{
    public class StudentPartnersViewModel : BaseViewModel
    {
        public ObservableCollection<StudentPartner> StudentPartners { get; set; }
        Page page;

        public StudentPartnersViewModel(Page page)
        {
            this.page = page;

            StudentPartners = new ObservableCollection<StudentPartner>();
            ExecuteRefreshCommandAsync();
        }

        Command refreshCommand;
        public Command RefreshCommand
        {
            get { return refreshCommand ?? (refreshCommand = new Command(async () => await ExecuteRefreshCommandAsync())); }
        }

        async Task ExecuteRefreshCommandAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await EasyMobileServiceClient.Current.Table<StudentPartner>().GetItemsAsync();
                StudentPartners.Clear();
                foreach (var sp in items)
                    StudentPartners.Add(sp);
            }
            catch (Exception ex)
            {
                 Logger.Report(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        StudentPartner selectedItem;
        public StudentPartner SelectedItem
        {
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");

                if (selectedItem != null)
                {
                    page.Navigation.PushAsync(new StudentPartnersDetailPage(selectedItem));

                    SelectedItem = null;
                }
            }
            get { return selectedItem; }
        }
    }
}