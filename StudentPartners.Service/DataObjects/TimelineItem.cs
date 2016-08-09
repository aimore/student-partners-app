using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Mobile.Server;

namespace StudentPartners.Service.DataObjects
{
    public class TimelineItem : EntityData
    {
        public virtual StudentPartner Author { get; set; }
        public string Text { get; set; }
        public string PhotoUrl { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}