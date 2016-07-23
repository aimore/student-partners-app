using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPartners.Models
{
    public class Comment
    {
        public StudentPartner Author { get; set; }
        public string Text { get; set; }
    }
}
