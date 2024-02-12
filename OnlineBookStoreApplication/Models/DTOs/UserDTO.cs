using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApplication.Models.DTOs
{
    public class UserDTO
    {
        [Required(ErrorMessage = "Email cannot be empty")]
        public string Email { get; set; }

        public string? Name { get; set; }

        public string? Token { get; set; }
        

        public string? Role { get; set; }

       

        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}
