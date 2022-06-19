using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Acme.BookStore.Permissions;

namespace Acme.BookStore.Users
{
    public class BookUserAppService:
        CrudAppService<
            BookUser
            , BookUserDto
            , Guid
            ,PagedAndSortedResultRequestDto
            ,CreateUpdateBookUserDto>,
        IBookUserAppService
    {
        public BookUserAppService(IRepository<BookUser,Guid> repository) : base(repository)
        {
        }
    }
}
