using Volo.Abp.Users;

namespace Acme.BookStore.Users;

public interface IBookUserLookupService : IUserLookupService<BookUser>
{

}
