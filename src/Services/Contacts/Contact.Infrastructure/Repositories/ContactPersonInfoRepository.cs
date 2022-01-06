using Contact.Application.Contracts.Persistence;
using Contact.Domain.ContactPersonAggregate;
using Contact.Infrastructure.Persistence;

namespace Contact.Infrastructure.Repositories
{
    public class ContactPersonInfoRepository : RepositoryBase<ContactPersonInfo>, IContactPersonInfoRepository
    {
        public ContactPersonInfoRepository(ContactContext dbContext) : base(dbContext)
        {
        }
    }
}
