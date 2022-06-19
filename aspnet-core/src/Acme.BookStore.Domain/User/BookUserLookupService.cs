using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Acme.BookStore.Users;

public class BookUserLookupService : UserLookupService<BookUser, IBookUserRepository>, IBookUserLookupService
{
    public BookUserLookupService(
        IBookUserRepository userRepository,
        IUnitOfWorkManager unitOfWorkManager)
        : base(
            userRepository,
            unitOfWorkManager)
    {

    }

    protected override BookUser CreateUser(IUserData externalUser)
    {
        return new BookUser(externalUser);
    }
}
