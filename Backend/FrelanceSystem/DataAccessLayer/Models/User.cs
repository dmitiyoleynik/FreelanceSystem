using DataAccessLayer.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }

        [Required]
        public UserRole Role { get; set; }
        
        public int Carma { get; set; }
        
        [Phone]
        public string Phone { get; set; }

        public string Location { get; set; }

        public DateTime? ExpirationDate { get; set; }
    }
}