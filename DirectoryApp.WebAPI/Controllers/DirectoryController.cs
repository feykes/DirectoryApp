using DirectoryApp.Application.DTOs;
using DirectoryApp.Application.Features.Commands.ContactInfo.ContactInfoCreate;
using DirectoryApp.Application.Features.Commands.ContactInfo.ContactInfoRemove;
using DirectoryApp.Application.Features.Commands.Person.PersonCreate;
using DirectoryApp.Application.Features.Commands.Person.PersonRemove;
using DirectoryApp.Application.Features.Queries.ContactInfo.ContactInfoList;
using DirectoryApp.Application.Features.Queries.Person.PersonDetailList;
using DirectoryApp.Application.Features.Queries.Person.PersonList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DirectoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllPersons()
        {
            var result = await _mediator.Send(new PersonListQueryRequest());
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePerson(PersonCreateCommandRequest personCreateCommandRequest)
        {
            await _mediator.Send(personCreateCommandRequest);
            return Ok("Kişi eklendi.");
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeletePerson(PersonRemoveCommandRequest personRemoveCommandRequest)
        {
            await _mediator.Send(personRemoveCommandRequest);
            return Ok("Kişi silindi.");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateContactInfo(ContactInfoCreateCommandRequest contactInfoCreateCommandRequest)
        {
            await _mediator.Send(contactInfoCreateCommandRequest);
            return Ok("İletişim bilgisi eklendi.");
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteContactInfo(ContactInfoRemoveCommandRequest contactInfoRemoveCommandRequest)
        {
            await _mediator.Send(contactInfoRemoveCommandRequest);
            return Ok("İletişim bilgisi silindi.");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetContactInfos()
        {
            var result = await _mediator.Send(new ContactInfoListQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPersonDetails()
        {
            var result = await _mediator.Send(new PersonDetailListQueryRequest());
            return Ok(result);
        }
    }
}
