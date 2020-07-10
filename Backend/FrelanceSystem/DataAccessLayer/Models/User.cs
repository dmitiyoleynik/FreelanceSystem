using DataAccessLayer.Enums;
using System;

namespace DataAccessLayer.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public UserRole Role { get; set; }
        
        public int Carma { get; set; }

        public string Phone { get; set; }

        public string Location { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}