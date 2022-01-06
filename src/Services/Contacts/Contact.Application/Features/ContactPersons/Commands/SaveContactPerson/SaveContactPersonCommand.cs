using MediatR;
using System;

namespace Contact.Application.Features.ContactPersons.Commands.SaveContactPerson
{
    public class SaveContactPersonCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Firm { get; set; }
    }
}
