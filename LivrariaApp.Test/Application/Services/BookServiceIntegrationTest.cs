using LivrariaApp.Application.Services;
using LivrariaApp.Domain.Interfaces.Repositories;
using LivrariaApp.Domain.Interfaces.Services;
using LivrariaApp.Domain.Models;
using LivrariaApp.Infrastructure.Data;
using LivrariaApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApp.Test.Application.Services
{
    public class BookServiceIntegrationTest
    {
        private readonly MySqlDbContext _dbContext;
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly Book _book;
        private readonly List<Book> _books;


        public BookServiceIntegrationTest()
        {
            var options = new DbContextOptionsBuilder<MySqlDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new MySqlDbContext(options);

            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _bookRepository = new BookRepository(_dbContext);
            _bookService = new BookService(_bookRepository);

            _book = new Book()
            {
                Id = 1,
                Author = "Zerid",
                Name = "Titanic",
                Description = "Description",
                RegisterDate = DateTime.Now,
            };

            _books = new List<Book>()
            {
                new Book {
                    Id = 1,
                    Author = "Zerid",
                    Name = "Titanic",
                    Description = "Description",
                    RegisterDate = DateTime.Now,
                },
                new Book {
                    Id = 2,
                    Author = "Zodic",
                    Name = "Ragnar",
                    Description = "Description",
                    RegisterDate = DateTime.Now,
                },
            };
        }

        [Fact(DisplayName = "Should get all books in database")]
        public async Task ShouldGetAllBooksInDatabase()
        {
            _books.ForEach(async book => await _bookService.Create(book));

            var result = await _bookService.GetAll();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(_books, result);
        }

        [Fact(DisplayName = "Should select a in database")]
        public async Task ShouldSelectBookInDatabase()
        {
            var createdBook = await _bookService.Create(_book);

            var result = await _bookService.GetById(createdBook.Id);

            Assert.NotNull(result);
            Assert.Equal(createdBook.Id, result.Id);
        }

        [Fact(DisplayName = "Should Create a book in database")]
        public async Task ShouldCreateBookInDatabase()
        {
            var result = await _bookService.Create(_book);

            var createdBook = await _dbContext.Books.FindAsync(result.Id);

            Assert.NotNull(createdBook);
            Assert.Equal(result.Id, createdBook?.Id);
            Assert.Equal(result.Name, createdBook?.Name);
            Assert.Equal(result.Author, createdBook?.Author);
            Assert.Equal(result.Description, createdBook?.Description);
            Assert.Equal(result.RegisterDate, createdBook?.RegisterDate);
        }

        [Fact(DisplayName = "Should Update a book in database")]
        public async Task ShouldUpdateBookInDatabase()
        {
            var createdBook = await _bookService.Create(_book);

            var book = new Book()
            {
                Id = createdBook.Id,
                Name = "Ragnar",
                Author = createdBook.Author,
                Description = "New Description",
                RegisterDate = DateTime.Now,
            };

            var updatedBook = await _bookService.Update(book);

            Assert.NotNull(updatedBook);
            Assert.Equal(updatedBook.Id, book?.Id);
            Assert.Equal(updatedBook.Name, book?.Name);
            Assert.Equal(updatedBook.Author, book?.Author);
            Assert.Equal(updatedBook.Description, book?.Description);
            Assert.Equal(updatedBook.RegisterDate, book?.RegisterDate);
        }

        [Fact(DisplayName = "Should delete a book in database")]
        public async Task ShouldDeleteBookInDatabase()
        {
            var createdBook = await _bookService.Create(_book);

            var result = await _bookService.Delete(createdBook.Id);

            Assert.True(result);
        }
    }
}
