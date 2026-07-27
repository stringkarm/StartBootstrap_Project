using Microsoft.AspNetCore.Mvc;
using StartBootstrap_Project.Models;
using System.Collections.Generic;

namespace StartBootstrap_Project.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (string.IsNullOrEmpty(model.FullName) ||
                string.IsNullOrEmpty(model.Email) ||
                string.IsNullOrEmpty(model.Password))
            {
                return Json(new { success = false, message = "All fields are required." });
            }

            if (model.Password != model.ConfirmPassword)
            {
                return Json(new { success = false, message = "Passwords do not match." });
            }

            string[] columns = { "FullName", "Email", "Password", "ConfirmPassword", "DateRegistered" };
            string[] values = {
                                $"'{model.FullName}'",
                                $"'{model.Email}'",
                                $"'{model.Password}'",
                                $"'{model.ConfirmPassword}'",
                                $"'{model.DateRegistered:yyyy-MM-dd HH:mm:ss}'"
        };

            string generatedQuery = DatabaseHelper.InsertAndGetQuery("Users", columns, values);

            return Json(new
            {
                success = true,
                message = "Data successfully stored in the console and query generated!",
                sqlQuery = generatedQuery
            });
        }
    }
}