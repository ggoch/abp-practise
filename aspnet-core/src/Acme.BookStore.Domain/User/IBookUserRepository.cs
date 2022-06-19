using Volo.Abp.Users;

namespace Acme.BookStore.Users;

public interface IBookUserRepository : IUserRepository<BookUser>
{

}
