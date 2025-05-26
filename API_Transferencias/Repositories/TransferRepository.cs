using API_Transferencias.Data;
using API_Transferencias.Interfaces;
using API_Transferencias.Models;
using Microsoft.EntityFrameworkCore;

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
    public async Task<Transfers> GetTransferById(Guid id)
    {
        return await _context.Transfers.FirstOrDefaultAsync(t => t.TransferId == id);
    }

    public async Task<List<Transfers>> GetTransfersByUserId(Guid userId)
    {
        return await _context.Transfers
            .Where(t => t.SenderId == userId || t.ReceiverId == userId)
            .ToListAsync();
    }

}
