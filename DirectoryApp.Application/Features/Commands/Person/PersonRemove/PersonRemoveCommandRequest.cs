using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Commands.Person.PersonRemove
{
    public class PersonRemoveCommandRequest : IRequest<PersonRemoveCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
