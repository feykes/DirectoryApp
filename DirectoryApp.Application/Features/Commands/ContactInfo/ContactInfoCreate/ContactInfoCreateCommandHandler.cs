using DirectoryApp.Application.Repositories;
using DirectoryApp.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Commands.ContactInfo.ContactInfoCreate
{
    public class ContactInfoCreateCommandHandler : IRequestHandler<ContactInfoCreateCommandRequest, ContactInfoCreateCommandResponse>
    {
        private readonly IContactInfoWriteRepository _contactInfoWriteRepository;

        public ContactInfoCreateCommandHandler(IContactInfoWriteRepository contactInfoWriteRepository)
        {
            _contactInfoWriteRepository = contactInfoWriteRepository;
        }

        public async Task<ContactInfoCreateCommandResponse> Handle(ContactInfoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var contactInfo = new DirectoryApp.Domain.Entity.ContactInfo()
            {
                Id = Guid.NewGuid(),
                InfoType = request.InfoType,
                Info = request.Info,
                PersonId=request.PersonId
            };
            await _contactInfoWriteRepository.AddAsync(contactInfo);
            await _contactInfoWriteRepository.SaveAsync();
            return new();
        }
    }
}
