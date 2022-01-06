using AutoMapper;
using Contact.Application.Features.ContactPersons.Commands.SaveContactPerson;
using Contact.Domain.ContactPersonAggregate;

namespace Contact.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactPerson, SaveContactPersonCommand>().ReverseMap();
        }
    }
}
