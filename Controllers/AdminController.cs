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
        [HttpPost]
        public IActionResult SaveChanges(Dictionary<int, string> UserUpdates)
        {
            if (UserUpdates != null)
            {
                foreach (var update in UserUpdates)
                {
                    var user = _context.Users.FirstOrDefault(u => u.Id == update.Key);
                    if (user != null)
                    {
                        user.Type = update.Value;
                    }
                }

                _context.SaveChanges();
            }

            return RedirectToAction("GetAllUsers");
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("GetAllUsers", "Admin");
        }

    }
}
