using DirectoryApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.Report.ReportList
{
    public class ReportListQueryRequest : IRequest<List<ReportListDto>>
    {
    }
}
