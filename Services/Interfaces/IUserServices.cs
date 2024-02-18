using mshop_api.Models;
using mshop_api.Models.DTO;

namespace mshop_api.Services.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<User> CreateUser(User user);
        Task<bool> UpdateUser(UserDTO user);
        Task<bool> DeleteUser(int id);
    }
}
