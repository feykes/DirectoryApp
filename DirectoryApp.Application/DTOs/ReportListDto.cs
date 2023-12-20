using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.DTOs
{
    public class ReportListDto
    {
        public Guid Id { get; set; }
        public DateTime RequestDate { get; set; }
        public bool State { get; set; }
    }
}
