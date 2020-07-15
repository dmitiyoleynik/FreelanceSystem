using System.ComponentModel.DataAnnotations;

namespace FrelanceSystem.ViewModels
{
    public class UserAuthData
    {
        [Required]
        [EmailAddress]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
