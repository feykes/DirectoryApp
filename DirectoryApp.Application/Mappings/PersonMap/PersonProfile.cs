using AutoMapper;
using DirectoryApp.Application.DTOs;
using DirectoryApp.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Mappings.PersonMap
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonListDto>().ReverseMap();
        }
    }
}
