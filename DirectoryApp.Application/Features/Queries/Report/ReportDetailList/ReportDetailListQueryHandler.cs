using AutoMapper;
using DirectoryApp.Application.DTOs;
using DirectoryApp.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.Report.ReportDetailList
{
    public class ReportDetailListQueryHandler : IRequestHandler<ReportDetailListQueryRequest, List<ReportDetailListDto>>
    {
        private readonly IReportReadRepository _reportReadRepository;
        private readonly IMapper _mapper;

        public ReportDetailListQueryHandler(IReportReadRepository reportReadRepository, IMapper mapper)
        {
            _reportReadRepository = reportReadRepository;
            _mapper = mapper;
        }

        public async Task<List<ReportDetailListDto>> Handle(ReportDetailListQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _reportReadRepository.GetAllAsync();
            return _mapper.Map<List<ReportDetailListDto>>(data);
        }
    }
}
