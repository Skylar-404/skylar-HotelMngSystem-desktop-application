using System;

namespace hotelmngsystem.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } = "EMPLOYEE";
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Status { get; set; } = "ACTIVE";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static readonly string[] AllRoles = { "EMPLOYER", "MANAGER", "EMPLOYEE" };

        /// <summary>
        /// In this application "EMPLOYER" is treated as the Administrator role
        /// (full access, including managing user/employee accounts).
        /// </summary>
        public bool IsAdmin => Role == "EMPLOYER";
    }
}
