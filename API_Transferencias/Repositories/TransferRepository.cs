using API_Transferencias.Data;
using API_Transferencias.Interfaces;
using API_Transferencias.Models;

namespace API_Transferencias.Repositories;

public class TransferRepository : ITransferRepository
{
    private readonly AppDbContext _context;

    public TransferRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Transfers> RegisterTransfer(Transfers transfers)
    {
        await _context.Set<Transfers>().AddAsync(transfers);
        return transfers;
    }
}
