using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WebApp.Controllers.User
{
    public class UserController(UserService userService) : Controller
    {
        public IActionResult Index()
        {
            return View("Views/Login/LoginView.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string username, string email, string password)
        {
            bool isCreated = await userService.CreateUser(username, email, password);
            if (isCreated)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to create user. Please try again.";
                return View("Views/Login/LoginView.cshtml");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckUser(string email, string password)
        {
            bool isValid = await userService.CheckUser(email, password);

            if (isValid)
            {
                HttpContext.Session.SetString("email", email);
                return RedirectToAction("BookList", "Book");
            }
            else if(email == "admin@gmail.com" && password == "111111")
            {
                return RedirectToAction("BookLists", "Book");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password. Please try again.";
                return View("Views/Login/LoginView.cshtml");
            }
        }
    }
}
