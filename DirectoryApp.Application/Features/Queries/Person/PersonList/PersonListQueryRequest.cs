using DirectoryApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.Person.PersonList
{
    public class PersonListQueryRequest : IRequest<ICollection<PersonListDto>>
    {
    }
}
