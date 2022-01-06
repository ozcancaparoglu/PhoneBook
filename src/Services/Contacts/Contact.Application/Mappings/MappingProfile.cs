using AutoMapper;
using Contact.Application.Features.ContactPersons.Commands.SaveContactPerson;
using Contact.Application.Features.ContactPersons.Queries.GetContactPersonList;
using Contact.Domain.ContactPersonAggregate;

namespace Contact.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContactPerson, SaveContactPersonCommand>().ReverseMap();
            CreateMap<ContactPerson, ContactPersonResponse>().ReverseMap();
        }
    }
}
