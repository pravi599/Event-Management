using EventProject.Models.DTOs;

namespace EventProject.Interfaces
{
    public interface IUserService
    {
        UserDTO Register(UserDTO userDTO);
        UserDTO Login(UserDTO userDTO);

    }
}
