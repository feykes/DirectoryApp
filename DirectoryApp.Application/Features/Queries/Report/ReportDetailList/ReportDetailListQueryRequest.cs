using DirectoryApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.Report.ReportDetailList
{
    public class ReportDetailListQueryRequest : IRequest<List<ReportDetailListDto>>
    {
    }
}
