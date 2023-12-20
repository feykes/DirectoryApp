using AutoMapper;
using DirectoryApp.Application.DTOs;
using DirectoryApp.Application.Repositories;
using DirectoryApp.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.Person.PersonList
{
    public class PersonListQueryHandler : IRequestHandler<PersonListQueryRequest, List<PersonListDto>>
    {
        private readonly IPersonReadRepository _personReadRepository;
        private readonly IMapper _mapper;

        public PersonListQueryHandler(IPersonReadRepository personReadRepository, IMapper mapper = null)
        {
            _personReadRepository = personReadRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonListDto>> Handle(PersonListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _personReadRepository.GetAllAsync();
            return _mapper.Map<List<PersonListDto>>(data);

        }
    }
}
