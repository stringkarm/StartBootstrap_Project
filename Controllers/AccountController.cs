using Microsoft.AspNetCore.Mvc;
using StartBootstrap_Project.Models;

namespace StartBootstrap_Project.Controllers
{
    public class AccountController : Controller
    {
        // 1. Displays the Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // 2. Processes the Login Form Submission
        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Hardcoded built-in credentials check
                if (model.Email == "karms@gmail.com" && model.Password == "admin123")
                {
                    // Redirects to the Index action inside HomeController on success
                    return RedirectToAction("Index", "Home");
                }

                // If credentials match fails, add an error message
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
            }

            // Return the model back to the view to retain inputs and display validation errors
            return View(model);
        }
    }
}