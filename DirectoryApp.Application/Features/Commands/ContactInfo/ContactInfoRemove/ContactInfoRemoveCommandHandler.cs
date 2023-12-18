using DirectoryApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Commands.ContactInfo.ContactInfoRemove
{
    public class ContactInfoRemoveCommandHandler : IRequestHandler<ContactInfoRemoveCommandRequest, ContactInfoRemoveCommandResponse>
    {
        private readonly IContactInfoWriteRepository _contactInfoWriteRepository;

        public ContactInfoRemoveCommandHandler(IContactInfoWriteRepository contactInfoWriteRepository)
        {
            _contactInfoWriteRepository = contactInfoWriteRepository;
        }

        public async Task<ContactInfoRemoveCommandResponse> Handle(ContactInfoRemoveCommandRequest request, CancellationToken cancellationToken)
        {
            await _contactInfoWriteRepository.RemoveAsync(request.Id);
            await _contactInfoWriteRepository.SaveAsync();
            return new();
        }
    }
}
