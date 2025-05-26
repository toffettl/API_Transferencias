using API_Transferencias.Models;

namespace API_Transferencias.Interfaces;

public interface ITransferRepository
{
    Task<Transfers> RegisterTransfer(Transfers transfers);
    Task<Transfers> GetTransferById(Guid id);
    Task<List<Transfers>> GetTransfersByUserId(Guid userId);
}
