using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Commands.Person.PersonCreate
{
    public class PersonCreateCommandRequest : IRequest<PersonCreateCommandResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
