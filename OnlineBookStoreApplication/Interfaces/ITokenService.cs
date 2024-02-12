using OnlineBookStoreApplication.Models.DTOs;

namespace OnlineBookStoreApplication.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
