using System.Threading.Tasks;
using API_Transferencias.Common;
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

    public async Task<OperationResult<User>> Delete(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null)
            return OperationResult<User>.Fail("Usuário não encontrado.");

        await _userRepository.DeleteUser(id);
        await _unitOfWork.CommitAsync();

        return OperationResult<User>.Ok(user);
    }

    public async Task<OperationResult<User>> Get(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        return user == null
            ? OperationResult<User>.Fail("Usuário não encontrado.")
            : OperationResult<User>.Ok(user);
    }

    public async Task<OperationResult<User>> Register(User user)
    {
        var createUser = new User
        {
            CPF = user.CPF,
            Email = user.Email,
            IncomingTransfers = user.IncomingTransfers,
            Name = user.Name,
            Password = user.Password,
            SentTransfers = user.SentTransfers,
            UserId = Guid.NewGuid(),
            Wallet = 1000
        };

        var newUser = await _userRepository.ResgisterAsync(createUser);
        await _unitOfWork.CommitAsync();

        return OperationResult<User>.Ok(newUser);
    }

    public async Task<OperationResult<User>> Update(User user)
    {
        var updateUser = await _userRepository.Update(user);
        if (updateUser == null)
            return OperationResult<User>.Fail("Usuário não encontrado para atualização.");

        await _unitOfWork.CommitAsync();
        return OperationResult<User>.Ok(updateUser);
    }
}