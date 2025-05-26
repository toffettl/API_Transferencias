using API_Transferencias.Common;
using API_Transferencias.Models;

namespace API_Transferencias.Interfaces;

public interface IUserService
{
    Task<OperationResult<User>> Get(Guid id);
    Task<OperationResult<User>> Register(User user);
    Task<OperationResult<User>> Update(User user);
    Task<OperationResult<User>> Delete(Guid id);
}
