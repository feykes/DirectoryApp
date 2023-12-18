using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Domain.Entity
{
    public class Report
    {
        public Guid Id { get; set; }
        public string RequestedLocation { get; set; }
        public string TotalPerson { get; set; }
        public string TotalPhone { get; set; }
        public DateTime RequestDate { get; set; }
        public bool State { get; set; }
    }
}
