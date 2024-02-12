using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApplication.Models.DTOs
{
    public class UserRegisterDTO : UserDTO
    {
        [Required(ErrorMessage = "Re type password cannot be empty")]
        [Compare("Password", ErrorMessage = "Password and retype password do not match")]
        public string ReTypePassword { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
