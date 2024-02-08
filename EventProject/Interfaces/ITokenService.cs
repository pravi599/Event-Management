using EventProject.Models.DTOs;

namespace EventProject.Interfaces
{
    public interface ITokenService
    {
        string GetToken(UserDTO user);
    }
}
