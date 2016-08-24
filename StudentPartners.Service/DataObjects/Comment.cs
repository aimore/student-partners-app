using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Mobile.Server;

namespace StudentPartners.Service.DataObjects
{
    public class Comment : EntityData
    {
        public virtual StudentPartner Author { get; set; }
        public string Text { get; set; }
    }
}
