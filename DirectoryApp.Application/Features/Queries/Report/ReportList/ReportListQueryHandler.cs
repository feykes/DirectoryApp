using AutoMapper;
using DirectoryApp.Application.DTOs;
using DirectoryApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.Report.ReportList
{
    public class ReportListQueryHandler : IRequestHandler<ReportListQueryRequest, List<ReportListDto>>
    {
        private readonly IReportReadRepository _reportReadRepository;
        private readonly IMapper _mapper;

        public ReportListQueryHandler(IReportReadRepository reportReadRepository, IMapper mapper)
        {
            _reportReadRepository = reportReadRepository;
            _mapper = mapper;
        }

        public async Task<List<ReportListDto>> Handle(ReportListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _reportReadRepository.GetAllAsync();
            return _mapper.Map<List<ReportListDto>>(data);
        }
    }
}
