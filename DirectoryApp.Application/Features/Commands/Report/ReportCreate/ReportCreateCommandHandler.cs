using DirectoryApp.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DirectoryApp.Application.Features.Commands.Report.ReportCreate
{
    public class ReportCreateCommandHandler : IRequestHandler<ReportCreateCommandRequest, ReportCreateCommandResponse>
    {
        private readonly IContactInfoReadRepository _contactInfoReadRepository;
        private readonly IReportWriteRepository _reportWriteRepository;

        public ReportCreateCommandHandler(IContactInfoReadRepository contactInfoReadRepository, IReportWriteRepository reportWriteRepository)
        {
            _contactInfoReadRepository = contactInfoReadRepository;
            _reportWriteRepository = reportWriteRepository;
        }

        public async Task<ReportCreateCommandResponse> Handle(ReportCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var persons = await _contactInfoReadRepository.Table.Where(p => (int)p.InfoType == 3 && p.Info == request.Location).Select(p => p.PersonId).Distinct().ToListAsync();
            var totalPerson = persons.Count;
            var phones = await _contactInfoReadRepository.Table.Where(p => (int)p.InfoType == 3 && p.Info == request.Location).Select(p => (int)p.InfoType == 1).ToListAsync();
            var totalPhone = phones.Count;
            await _reportWriteRepository.AddAsync(new()
            {
                Id = Guid.NewGuid(),
                RequestedLocation = request.Location,
                TotalPerson = totalPerson.ToString(),
                TotalPhone = totalPhone.ToString(),
                RequestDate = DateTime.UtcNow,
                State = true
            });
            await _reportWriteRepository.SaveAsync();
            return new();
        }
    }
}
