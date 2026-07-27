using Microsoft.AspNetCore.Mvc;
using StartBootstrap_Project.Models;

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

            if (model.Id == 0)
            {
                model.Id = 1;
            }

            string[] columns = { "FullName", "Email", "Password", "ConfirmPassword", "DateRegistered" };
            string[] values = {
                $"'{model.FullName}'",
                $"'{model.Email}'",
                $"'{model.Password}'",
                $"'{model.ConfirmPassword}'",
                $"'{model.DateRegistered:yyyy-MM-dd HH:mm:ss}'"
            };

            string insertQuery = DatabaseHelper.InsertAndGetQuery("Users", columns, values);
            string updateQuery = DatabaseHelper.UpdateAndGetQuery("Users", new string[] { "FullName" }, new string[] { $"'{model.FullName}'" }, model.Id.ToString());
            string deleteQuery = DatabaseHelper.DeleteAndGetQuery("Users", model.Id.ToString());

            return Json(new
            {
                success = true,
                message = "All queries successfully generated using ID and stored in console!",
                insertQuery = insertQuery,
                updateQuery = updateQuery,
                deleteQuery = deleteQuery
            });
        }
    }
}