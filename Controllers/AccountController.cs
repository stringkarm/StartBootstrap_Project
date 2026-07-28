using Microsoft.AspNetCore.Mvc;
using StartBootstrap_Project.Models;
using System;

namespace StartBootstrap_Project.Controllers
{
    public class AccountController : Controller
    {

        private string GetTableName(Type modelType)
        {
            string name = modelType.Name;
            if (name.EndsWith("ViewModel"))
            {
                name = name.Substring(0, name.Length - "ViewModel".Length);
            }
            return name;
        }

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
        public IActionResult Register([FromBody] RegisterViewModel model)
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

            string tableName = GetTableName(model.GetType());

            string[] columns = { "FullName", "Email", "Password", "ConfirmPassword", "DateRegistered" };

            object[] values = {
                model.FullName,
                model.Email,
                model.Password,
                model.ConfirmPassword,
                model.DateRegistered
            };

            string insertQuery = DatabaseHelper.InsertAndGetQuery(tableName, columns, values);
            string updateQuery = DatabaseHelper.UpdateAndGetQuery(tableName, new string[] { "FullName" }, new object[] { model.FullName }, $"Id = {model.Id}");
            string deleteQuery = DatabaseHelper.DeleteAndGetQuery(tableName, $"Id = {model.Id}");

            return Json(new
            {
                success = true,
                message = $"All queries for table [{tableName}] successfully generated and stored in console!",
                insertQuery = insertQuery,
                updateQuery = updateQuery,
                deleteQuery = deleteQuery
            });
        }

        [HttpGet]
        public IActionResult ViewList()
        {
            string tableName = "Register";
            string selectQuery = $"SELECT * FROM {tableName}";

            //WAY GAMIT
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"DYNAMIC SELECT QUERY FOR [{tableName}] STORED IN CONSOLE:");
            Console.WriteLine(selectQuery);
            Console.WriteLine("------------------------------------------");

            return Json(new { success = true, message = selectQuery });
        }

        [HttpPost]
        public IActionResult Update([FromBody] RegisterViewModel model)
        {
            
            if (model.Id <= 0)
            {
                model.Id = 1; 
            }

            string tableName = GetTableName(model.GetType());

            string[] columns = { "FullName", "Password" };
            object[] values = { model.FullName, model.Password };

            string updateQuery = DatabaseHelper.UpdateAndGetQuery(tableName, columns, values, $"Id = {model.Id}");

            return Json(new { success = true, message = updateQuery });
        }

        [HttpPost]
        public IActionResult Delete()
        {
            string tableName = "Register";
            string deleteQuery = DatabaseHelper.DeleteAndGetQuery(tableName, "Id = 1");

            return Json(new { success = true, message = deleteQuery });
        }
    }
}