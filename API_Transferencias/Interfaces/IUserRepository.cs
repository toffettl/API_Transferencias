using API_Transferencias.Models;

namespace API_Transferencias.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserById(Guid id);
        Task<User> ResgisterAsync(User user);
        Task<User> Update(User user);
        Task<User> DeleteUser(Guid id);
    }
}
