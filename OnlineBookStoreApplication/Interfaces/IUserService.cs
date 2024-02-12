using OnlineBookStoreApplication.Models;
using OnlineBookStoreApplication.Models.DTOs;

namespace OnlineBookStoreApplication.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO userDTO);
        UserDTO Register(UserRegisterDTO userRegisterDTO);

        User GetById(string id);
    }
}
