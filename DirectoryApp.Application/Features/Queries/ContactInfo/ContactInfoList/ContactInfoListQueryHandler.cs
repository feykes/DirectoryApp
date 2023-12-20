using AutoMapper;
using DirectoryApp.Application.DTOs;
using DirectoryApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.ContactInfo.ContactInfoList
{
    public class ContactInfoListQueryHandler : IRequestHandler<ContactInfoListQueryRequest, List<ContactInfoListDto>>
    {
        private readonly IContactInfoReadRepository _contactInfoReadRepository;
        private readonly IMapper _mapper;

        public ContactInfoListQueryHandler(IContactInfoReadRepository contactInfoReadRepository, IMapper mapper)
        {
            _contactInfoReadRepository = contactInfoReadRepository;
            _mapper = mapper;
        }

        public async Task<List<ContactInfoListDto>> Handle(ContactInfoListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _contactInfoReadRepository.GetAllAsync();
            return _mapper.Map<List<ContactInfoListDto>>(data);
        }
    }
}
