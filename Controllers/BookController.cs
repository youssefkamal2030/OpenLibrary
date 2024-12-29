using LibraryInventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryInventory.Controllers
{
    public class BookController : BaseController
    {
        private readonly BookBL _bookBL = new BookBL();
        public IActionResult Index()
        {
            var books = _bookBL.GetAllBooks();
            return View(books);
        }


        public IActionResult GetBook(int id)
        {
            Book? book = _bookBL.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View("Details", book);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookBL.AddBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }


        public IActionResult Edit(int id)
        {
            Book? book = _bookBL.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }


        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _bookBL.UpdateBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _bookBL.GetBook(id);
            if (book == null)
            {
                return NotFound(); 
            }

            return View(book); 
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = _bookBL.GetBook(id);
            if (book != null)
            {
                _bookBL.RemoveBook(id);
            }

            return RedirectToAction("Index","Book"); 
        }

    }
}
