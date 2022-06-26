using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;
using Acme.BookStore.Authors;

namespace Acme.BookStore.Books
{
    public class BookAppService_Tests:BookStoreApplicationTestBase
    {
        private readonly IBookAppService bookAppService;
        private readonly IAuthorAppService authorAppService;

        public BookAppService_Tests()
        {
            bookAppService = GetRequiredService<IBookAppService>();
            authorAppService = GetRequiredService<IAuthorAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Book()
        {
            //Act
            var result = await bookAppService.GetListAsync(new PagedAndSortedResultRequestDto());

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(x => x.Name == "19484" && x.AuthorName == "George Orwell");
        }

        [Fact]
        public async Task Should_Create_A_Vaild_Book()
        {
            var authors = await authorAppService.GetListAsync(new GetAuthorListDto());
            var firstAuthor = authors.Items.First();

            //Act
            var result = await bookAppService.CreateAsync(
                new CreateUpdateBookDto
            {
                AuthorId = firstAuthor.Id,
                Name = "New test book 425",
                Price = 10,
                PublishDate = DateTime.Now,
                Type = BookType.ScienceFiction
            });

            //Asset
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New test book 425");
        }

        [Fact]
        public async Task Should_Not_Create_A_Book_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await bookAppService.CreateAsync
                (
                    new CreateUpdateBookDto
                    {
                        Name = "",
                        Price = 10,
                        PublishDate = DateTime.Now,
                        Type = BookType.ScienceFiction
                    }
                );
            });

            exception.ValidationErrors.ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }
    }
}
