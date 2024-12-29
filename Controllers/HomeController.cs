using LibraryInventory.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryInventory.Controllers
{
    public class HomeController : BaseController
    {
       
        private readonly BookBL bookBL = new BookBL();

       
        public IActionResult Index()
        {

            return View(bookBL.GetAllBooks().ToList());
        }
       
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
