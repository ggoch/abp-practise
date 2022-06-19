using System;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly AuthorManager authorManager;

        public BookStoreDataSeederContributor(
            IRepository<Book, Guid> bookRepository,
            IAuthorRepository authorRepository,
            AuthorManager authorManager)
        {
            _bookRepository = bookRepository;
            this.authorRepository = authorRepository;
            this.authorManager = authorManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if(await _bookRepository.GetCountAsync() <= 0)
            {
                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "19484",
                        Type = BookType.Dystopia,
                        PublishDate = new DateTime(1946, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );

                await _bookRepository.InsertAsync(
                    new Book
                    {
                        Name = "jgok;ogij",
                        Type = BookType.ScienceFiction,
                        PublishDate = new DateTime(1946, 9, 22),
                        Price = 37.84f
                    },
                    autoSave: true
                );
            }

            if (await authorRepository.GetCountAsync() <= 0)
            {
                await authorRepository.InsertAsync(
                    await authorManager.CreateAsync(
                        "George Orwell",
                        new DateTime(1903, 06, 25),
                        "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                        )
                    );

                await authorRepository.InsertAsync(
                    await authorManager.CreateAsync(
                        "Douglas Adams",
                        new DateTime(1952, 03, 11),
                        "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                        )
                    );
            }
        }
    }
}
