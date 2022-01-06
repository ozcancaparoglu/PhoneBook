using Contact.Application.Contracts.Persistence;
using Contact.Domain.ContactPersonAggregate;
using Contact.Infrastructure.Persistence;

namespace Contact.Infrastructure.Repositories
{
    public class ContactPersonRepository : RepositoryBase<ContactPerson>, IContactPersonRepository
    {
        public ContactPersonRepository(ContactContext dbContext) : base(dbContext)
        {
        }
    }
}
