using LibraryInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInventory.Controllers
{
    public class AdminController : BaseController
    {
        private readonly Context _context = new Context();  

        // Get : /Admin/GetAllUsers
        public IActionResult GetAllUsers()
        {
            List<User> Users = _context.Users.ToList();
            return View("AllUsers", Users);
        }
        [HttpPost]
        public IActionResult SaveChanges(int id ,User user)
        {
            User UpdatedUser = _context.Users.FirstOrDefault(u => u.Id == id);
			UpdatedUser.Type = user.Type;

            _context.SaveChanges();
            return RedirectToAction("GetAllUsers", "Admin");   
        }
    }
}
