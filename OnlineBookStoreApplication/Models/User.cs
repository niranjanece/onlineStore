using System.ComponentModel.DataAnnotations;

namespace OnlineBookStoreApplication.Models
{
    public class User
    {
        [Key]
        public string Email { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public string Address { get; set; }
        public byte[] Password { get; set; }

        public byte[] Key { get; set; }
    }
}
