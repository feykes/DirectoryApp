using DirectoryApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.DTOs
{
    public class ContactInfoListDto
    {
        public Guid Id { get; set; }
        public InfoTypes InfoType { get; set; }
        public string Info { get; set; }
        public Guid PersonId { get; set; }
    }
}
