using Contact.Application.Features.ContactPersons.Commands.DeleteContactPerson;
using Contact.Application.Features.ContactPersons.Commands.SaveContactPerson;
using Contact.Application.Features.ContactPersons.Queries.GetContactPersonList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet(Name = "GetContacts")]
        [ProducesResponseType(typeof(IEnumerable<ContactPersonResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ContactPersonResponse>>> GetContacts()
        {
            var query = new GetContactPersonListQuery();
            var contacts = await _mediator.Send(query);
            return Ok(contacts);
        }

        [HttpPost(Name = "SaveContactPerson")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> SaveContactPerson([FromBody] SaveContactPersonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteContactPerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteContactPerson(Guid id)
        {
            var command = new DeleteContactPersonCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }




    }
}
