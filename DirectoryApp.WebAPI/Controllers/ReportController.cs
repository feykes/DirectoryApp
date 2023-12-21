using DirectoryApp.Application.Features.Commands.Report.ReportCreate;
using DirectoryApp.Application.Features.Queries.Report.ReportDetailList;
using DirectoryApp.Application.Features.Queries.Report.ReportList;
using DirectoryApp.Infrastructure.RabbitMQ;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DirectoryApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly RabbitMQService _rabbitmqService;
        private readonly MethodConsumer _methodConsumer;

        public ReportController(IMediator mediator, RabbitMQService rabbitmqService, MethodConsumer methodConsumer)
        {
            _mediator = mediator;
            _rabbitmqService = rabbitmqService;
            _methodConsumer = methodConsumer;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateReportInvoke(ReportCreateCommandRequest reportCreateCommandRequest)
        {
            var jsonText = JsonConvert.SerializeObject(reportCreateCommandRequest);

            _rabbitmqService.PublishToQueue(jsonText);
            _methodConsumer.StartConsuming();

            return Ok("Rapor talebi alındı.");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReports()
        {
            var result = await _mediator.Send(new ReportListQueryRequest());
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReportDetails()
        {
            var result = await _mediator.Send(new ReportDetailListQueryRequest());
            return Ok(result);
        }
    }
}
