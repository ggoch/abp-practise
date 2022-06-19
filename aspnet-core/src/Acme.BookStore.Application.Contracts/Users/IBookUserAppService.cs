using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Users
{
    public interface IBookUserAppService :
    ICrudAppService<
    BookUserDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateBookUserDto>
    {

    }
}
