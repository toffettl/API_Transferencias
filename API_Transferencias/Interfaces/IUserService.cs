using API_Transferencias.Models;

namespace API_Transferencias.Interfaces;

public interface IUserService
{
    Task<User> Register(User user);
    Task<User> Update (User user);
    Task<User> Delete (Guid id);
    Task<User> Get (Guid id);
}
