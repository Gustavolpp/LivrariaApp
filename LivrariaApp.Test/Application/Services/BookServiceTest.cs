using LivrariaApp.Domain.Interfaces.Services;
using LivrariaApp.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaApp.Test.Application.Services
{
    public class BookServiceTest
    {
        private readonly Mock<IBookService> _serviceMook;
        private IBookService _bookService;
        private readonly Book _book;
        private readonly List<Book> _books;

        public BookServiceTest()
        {
            _serviceMook = new Mock<IBookService>();

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

        [Fact(DisplayName = "Should get all books")]
        public async Task ShouldGetAllBooks()
        {
            _serviceMook.Setup(x => x.GetAll()).ReturnsAsync(_books);
            _bookService = _serviceMook.Object;

            var result = await _bookService.GetAll();
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should select a book by Id")]
        public async Task ShouldSelectBookById()
        {
            _serviceMook.Setup(x => x.GetById(_book.Id)).ReturnsAsync(_book);
            _bookService = _serviceMook.Object;

            var result = await _bookService.GetById(_book.Id);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should create a book")]
        public async Task ShouldCreateBook()
        {
            _serviceMook.Setup(x => x.Create(_book)).ReturnsAsync(_book);
            _bookService = _serviceMook.Object;

            var result = await _bookService.Create(_book);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should update a book")]
        public async Task ShouldUpdateBook()
        {
            _serviceMook.Setup(x => x.Update(_book)).ReturnsAsync(_book);
            _bookService = _serviceMook.Object;

            var result = await _bookService.Update(_book);
            Assert.NotNull(result);
        }

        [Fact(DisplayName = "Should delete a book")]
        public async Task ShouldDeleteBook()
        {
            _serviceMook.Setup(x => x.Delete(_book.Id)).ReturnsAsync(true);
            _bookService = _serviceMook.Object;

            var result = await _bookService.Delete(_book.Id);
            Assert.True(result);
        }
    }
}
