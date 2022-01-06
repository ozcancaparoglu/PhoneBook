using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Report.Api.Entities;
using Report.Api.Entities.Enums;
using Report.Api.Repositories.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Report.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IContactReportRepository _repository;
        private readonly IPublishEndpoint _publishEndpoint;

        public ReportController(IContactReportRepository repository, IPublishEndpoint publishEndpoint) : this(repository)
        {
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        public ReportController(IContactReportRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [Route("[action]")]
        [HttpPost("{location}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetReport(string location)
        {
            await _repository.CreateReport(
                new ContactReport()
                {
                    CreatedDate = DateTime.Now,
                    Status = State.Pending
                });

            return Accepted();
        }
    }
}
