using Microsoft.AspNetCore.Mvc;
using Mission11_Naumann.Models;
using Mission11_Naumann.Models.ViewModels;
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

            var book = new BooksListViewModel
            {
                Books = _repo.Books
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()

                }
            };
                
            return View(book);
        }
    }
}
