using API_Transferencias.Models;

namespace API_Transferencias.Interfaces
{
    public interface IUserRepository
    {
        Task<User> ResgisterAsync(User user);
        Task<User> DeleteUser(Guid id);
        Task<User> Update(User user);
        Task<User> GetUserById(Guid id);
    }
}
