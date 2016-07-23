using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPartners.Models
{
    public class TimelineItem
    {
        public StudentPartner Author { get; set; }
        public string Text { get; set; }
        public string PhotoUrl { get; set; }
        public ObservableCollection<Comment> Comments { get; set; }
    }
}
