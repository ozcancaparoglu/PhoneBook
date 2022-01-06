using Contact.Application.Features.ContactPersons.Commands.SaveContactPerson;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Contact.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactPersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactPersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "SaveContactPerson")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> SaveContactPerson([FromBody] SaveContactPersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
