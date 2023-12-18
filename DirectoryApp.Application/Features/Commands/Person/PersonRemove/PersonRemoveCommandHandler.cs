using DirectoryApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Commands.Person.PersonRemove
{
    public class PersonRemoveCommandHandler : IRequestHandler<PersonRemoveCommandRequest, PersonRemoveCommandResponse>
    {
        private readonly IPersonWriteRepository _personWriteRepository;
        private readonly IContactInfoReadRepository _contactInfoReadRepository;
        private readonly IContactInfoWriteRepository _contactInfoWriteRepository;

        public PersonRemoveCommandHandler(IPersonWriteRepository personWriteRepository, IContactInfoWriteRepository contactInfoWriteRepository, IContactInfoReadRepository contactInfoReadRepository)
        {
            _personWriteRepository = personWriteRepository;
            _contactInfoWriteRepository = contactInfoWriteRepository;
            _contactInfoReadRepository = contactInfoReadRepository;
        }

        public async Task<PersonRemoveCommandResponse> Handle(PersonRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            List<DirectoryApp.Domain.Entity.ContactInfo> contactInfos = _contactInfoReadRepository.Table.Where(ci=>ci.PersonId==request.Id).ToList();

            _contactInfoWriteRepository.RemoveRange(contactInfos);
            await _contactInfoWriteRepository.SaveAsync();
            await _personWriteRepository.RemoveAsync(request.Id);
            await _personWriteRepository.SaveAsync();
            return new();
        }
    }
}
