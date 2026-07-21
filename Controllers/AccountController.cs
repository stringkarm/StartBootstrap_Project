using Microsoft.AspNetCore.Mvc;
using StartBootstrap_Project.Models;
using System.Diagnostics;

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

            Debug.WriteLine("------------------------------------------");
            Debug.WriteLine("NEW REGISTRATION RECEIVED:");
            Debug.WriteLine("Full Name: " + model.FullName);
            Debug.WriteLine("Email: " + model.Email);
            Debug.WriteLine("Password: " + model.Password);
            Debug.WriteLine("------------------------------------------");

            return Json(new
            {
                success = true,
                message = "Registration successful!",
                userData = new
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password
                }
            });
        }
    }
}