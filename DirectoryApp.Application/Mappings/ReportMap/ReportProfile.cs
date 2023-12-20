using AutoMapper;
using DirectoryApp.Application.DTOs;
using DirectoryApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Mappings.ReportMap
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Report, ReportListDto>().ReverseMap();
        }
    }
}
