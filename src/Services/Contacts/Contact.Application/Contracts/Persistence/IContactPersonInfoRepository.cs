using Contact.Domain.ContactPersonAggregate;

namespace Contact.Application.Contracts.Persistence
{
    public interface IContactPersonInfoRepository : IAsyncRepository<ContactPersonInfo>
    {
    }
}
