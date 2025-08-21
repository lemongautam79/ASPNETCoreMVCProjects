using ASPNETCoreMVCProjects.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCoreMVCProjects.Controllers
{
    public class BookController : Controller
    {
        // Static list of demo
        private static List<Book> books = new List<Book>();

        //public IActionResult Index(string authorFilter)
        //{
        //    //Get unique authors for dropdown
        //    ViewBag.Authors = books.Select(b=>b.Author).Distinct().ToList();

        //    //Filter by author if selected
        //    var filteredBooks = string.IsNullOrEmpty(authorFilter)
        //        ? books
        //        : books.Where(b => b.Author == authorFilter).ToList();

        //    // Sort latest added on top (by bookId descending)
        //    filteredBooks = filteredBooks.OrderByDescending(b=>b.BookId).ToList();

        //    return View(filteredBooks);
        //}

        public IActionResult Index(string authorFilter)
        {
            ViewBag.Authors = books.Select(b => b.Author).Distinct().ToList();
            ViewBag.SelectedAuthor = authorFilter; // optional

            var filtered = string.IsNullOrEmpty(authorFilter)
                ? books
                : books.Where(b => b.Author == authorFilter).ToList();

            return View(filtered.OrderByDescending(b => b.BookId).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                // Auto increment Bookid
                book.BookId = books.Count > 0 ? books.Max(b => b.BookId) + 1 : 1;

                books.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
