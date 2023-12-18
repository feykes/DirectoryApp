using DirectoryApp.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Commands.ContactInfo.ContactInfoCreate
{
    public class ContactInfoCreateCommandRequest : IRequest<ContactInfoCreateCommandResponse>
    {
        public Guid PersonId { get; set; }
        public InfoTypes InfoType { get; set; }
        public string Info { get; set; }
    }
}
