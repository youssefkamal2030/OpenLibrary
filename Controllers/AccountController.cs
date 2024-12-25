using LibraryInventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInventory.Controllers
{
    public class AccountController : BaseController
    {
        private readonly Context _context = new Context();


        // GET: /Account/Register
        public IActionResult Register()
        {
            return View(new User());
        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View(user); 
            }
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View(new User());
        }
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("LoggedIn", "0");
            HttpContext.Session.SetString("UserType", "Guest");
            return RedirectToAction("Index","Home");
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (existingUser != null)
            {
                HttpContext.Session.SetString("UserType", existingUser.Type);
                HttpContext.Session.SetString("UserName", existingUser.Name);
                HttpContext.Session.SetString("LoggedIn", "1");
                if (existingUser.Type=="Guest")
                {
                    return RedirectToAction("Index", "Home");
                }
                  else if (existingUser.Type == "Admin")
                {
                    bool isAdmin = existingUser.Type == "admin";

                    return RedirectToAction("Dashboard", "Home");
                }
            }
          
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(user);
        }
    }
}