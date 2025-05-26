using API_Transferencias.Common;
using API_Transferencias.Models;

namespace API_Transferencias.Interfaces;

public interface ITransferService
{
    Task<Transfers> CheckBalance(Guid id, decimal amount);
    Task<Transfers> GetTransferById(Guid id);
    Task<OperationResult<List<Transfers>>> GetTransfersByUserId(Guid userId);
    Task<OperationResult<Transfers>> MakeTransfer(Transfers transfers);
}
