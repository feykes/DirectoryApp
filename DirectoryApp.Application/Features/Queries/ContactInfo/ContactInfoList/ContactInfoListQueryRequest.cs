using DirectoryApp.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryApp.Application.Features.Queries.ContactInfo.ContactInfoList
{
    public class ContactInfoListQueryRequest : IRequest<List<ContactInfoListDto>>
    {
    }
}
