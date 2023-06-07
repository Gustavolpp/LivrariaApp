using LivrariaApp.Domain.Interfaces.Services;
using LivrariaApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAll();

            return View(books);
        }

        public async Task<IActionResult> Details(long id)
        {
            var model = await _bookService.GetById(id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bookService.Create(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var model = await _bookService.GetById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bookService.Update(model);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(long id)
        {
            await _bookService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
