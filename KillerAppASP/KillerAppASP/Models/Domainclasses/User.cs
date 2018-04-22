using System;

namespace KillerAppASP.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastOnline { get; set; }
    }
}