using AutoMapper;
using DirectoryApp.Application.DTOs;
using DirectoryApp.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.Person.PersonDetailList
{
    public class PersonDetailListQueryHandler : IRequestHandler<PersonDetailListQueryRequest, List<PersonDetailDto>>
    {
        private readonly IPersonReadRepository _personReadRepository;
        private readonly IMapper _mapper;

        public PersonDetailListQueryHandler(IPersonReadRepository personReadRepository, IMapper mapper)
        {
            _personReadRepository = personReadRepository;
            _mapper = mapper;
        }

        public async Task<List<PersonDetailDto>> Handle(PersonDetailListQueryRequest request, CancellationToken cancellationToken)
        {
            var personDetails = await _personReadRepository.Table.Include(x => x.ContactInfos).ToListAsync();
            return _mapper.Map<List<PersonDetailDto>>(personDetails);

        }
    }
}
