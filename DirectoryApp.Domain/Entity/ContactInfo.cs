using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Domain.Entity
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public InfoTypes InfoType { get; set; }
        public string Info { get; set; }
        public Guid PersonId { get; set; }
    }
    public enum InfoTypes
    {
        Phone,
        Mail,
        Location
    }
}
