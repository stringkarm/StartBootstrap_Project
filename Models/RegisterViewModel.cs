using System;

namespace StartBootstrap_Project.Models
{
    public class RegisterViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public DateTime DateRegistered { get; set; } = DateTime.Now;

       
    }
}