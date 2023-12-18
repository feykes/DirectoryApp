using DirectoryApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Commands.Person.PersonCreate
{
    public class PersonCreateCommandHandler : IRequestHandler<PersonCreateCommandRequest, PersonCreateCommandResponse>
    {
        private readonly IPersonWriteRepository _personWriteRepository;

        public PersonCreateCommandHandler(IPersonWriteRepository personWriteRepository)
        {
            _personWriteRepository = personWriteRepository;
        }

        public async Task<PersonCreateCommandResponse> Handle(PersonCreateCommandRequest request, CancellationToken cancellationToken)
        {
            await _personWriteRepository.AddAsync(new()
            {
                Id=Guid.NewGuid(),
                Name=request.Name,
                Surname=request.Surname,
                Company=request.Company
            });
            await _personWriteRepository.SaveAsync();
            return new();
        }
    }
}
