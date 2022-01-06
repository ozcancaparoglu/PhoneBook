using Contact.Domain.ContactPersonAggregate;

namespace Contact.Application.Contracts.Persistence
{
    public interface IContactPersonRepository : IAsyncRepository<ContactPerson>
    {
    }
}
