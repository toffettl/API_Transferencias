using System.Threading.Tasks;
using API_Transferencias.Interfaces;
using API_Transferencias.Models;

namespace API_Transferencias.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<User> Delete(Guid id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return null;
        }

        _userRepository.DeleteUser(id);
        _unitOfWork.CommitAsync();

        return user;
    }

    public Task<User> Get(Guid id)
    {
        var user = _userRepository.GetUserById(id);
        if (user == null)
        {
            return null;
        }

        return user;
    }

    public Task<User> Register(User user)
    {
        var createUser = new User
        {
            CPF = user.CPF,
            Email = user.Email,
            IncomingTransfers = user.IncomingTransfers,
            Name = user.Name,
            Password = user.Password,
            SentTransfers = user.SentTransfers,
            UserId = user.UserId,
            Wallet = 1000
        };

        var newUser = _userRepository.ResgisterAsync(createUser);
        _unitOfWork.CommitAsync();

        return newUser;
    }

    public Task<User> Update(User user)
    {
        var updateUser = _userRepository.Update(user);
        if (updateUser == null)
        {
            return null;
        }

        _unitOfWork.CommitAsync();

        return updateUser;
    }
}
