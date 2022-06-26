using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using System.Text;

namespace Acme.BookStore.Books
{
    public class AuthorLookupDto:EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
