using Microsoft.AspNetCore.Mvc;

namespace LivrariaApp.Controllers
{
    public class BooksController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            return View();
        }
    }
}
