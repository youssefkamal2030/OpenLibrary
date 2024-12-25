using LibraryInventory.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        ViewBag.IsAdmin = HttpContext.Session.GetString("UserType") == "Admin";
        ViewBag.IsLoggedIn = HttpContext.Session.GetString("LoggedIn") == "1";
        ViewBag.UserName = HttpContext.Session.GetString("UserName") ?? "Guest";
        base.OnActionExecuting(filterContext);
    }
}