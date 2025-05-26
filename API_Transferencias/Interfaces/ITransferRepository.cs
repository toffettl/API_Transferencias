using API_Transferencias.Models;

namespace API_Transferencias.Interfaces;

public interface ITransferRepository
{
    Task<Transfers> RegisterTransfer(Transfers transfers);
}
