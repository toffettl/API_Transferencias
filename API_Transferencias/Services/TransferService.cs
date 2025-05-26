using System.Linq.Expressions;
using API_Transferencias.Common;
using API_Transferencias.Interfaces;
using API_Transferencias.Models;
using API_Transferencias.Repositories;

namespace API_Transferencias.Services;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _transferRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    public TransferService(ITransferRepository transferRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _transferRepository = transferRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Transfers> CheckBalance(Guid id, decimal amount)
    {
        var user = await _userRepository.GetUserById(id);

        if (user == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        if (user.Wallet < amount)
        {
            throw new Exception("Saldo insuficiente.");
        }

        return new Transfers
        {
            Amount = amount,
            SenderId = user.UserId,
        };
    }

    public async Task<Transfers> GetTransferById(Guid id)
    {
        var transfer = await _transferRepository.GetTransferById(id);

        if (transfer == null)
        {
            throw new Exception("Transferência não encontrada.");
        }

        return transfer;
    }

    public async Task<OperationResult<List<Transfers>>> GetTransfersByUserId(Guid userId)
    {
        var transfers = await _transferRepository.GetTransfersByUserId(userId);

        if (transfers == null || !transfers.Any())
            return OperationResult<List<Transfers>>.Fail("Nenhuma transferência encontrada.");

        return OperationResult<List<Transfers>>.Ok(transfers);
    }

    public async Task<OperationResult<Transfers>> MakeTransfer(Transfers transfers)
    {
        var sender = await _userRepository.GetUserById(transfers.SenderId);
        var recipient = await _userRepository.GetUserById(transfers.ReceiverId);

        if (sender == null || recipient == null)
        {
            return OperationResult<Transfers>.Fail("Sender or recipient not found.");
        }

        if (sender.Wallet < transfers.Amount)
        {
            return OperationResult<Transfers>.Fail("Insufficient balance to make the transfer.");
        }

        sender.Wallet -= transfers.Amount;
        recipient.Wallet += transfers.Amount;

        await _userRepository.Update(sender);
        await _userRepository.Update(recipient);

        var result = await _transferRepository.RegisterTransfer(transfers);
        await _unitOfWork.CommitAsync();

        return OperationResult<Transfers>.Ok(result);
    }
}
