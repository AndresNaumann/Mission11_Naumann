using Microsoft.AspNetCore.Mvc;
using Mission11_Naumann.Models;
using System.Diagnostics;

namespace Mission11_Naumann.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
   
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;

            var bookData = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);

            return View(bookData);
        }
    }
}
