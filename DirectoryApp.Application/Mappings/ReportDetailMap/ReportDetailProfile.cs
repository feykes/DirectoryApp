using AutoMapper;
using DirectoryApp.Application.DTOs;
using DirectoryApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Mappings.ReportDetailMap
{
    public class ReportDetailProfile : Profile
    {
        public ReportDetailProfile()
        {
            CreateMap<Report, ReportDetailListDto>().ReverseMap();
        }
    }
}
