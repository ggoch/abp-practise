using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;
using Acme.BookStore.EntityFrameworkCore;
//using Volo.CmsKit.EntityFrameworkCore;

namespace Acme.BookStore.Users;

public class EfCoreBookUserRepository : EfCoreUserRepositoryBase<BookStoreDbContext, BookUser>, IBookUserRepository
{
    public EfCoreBookUserRepository(IDbContextProvider<BookStoreDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}
