using API_Transferencias.Data;

namespace API_Transferencias.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
        Task<int> CompleteAsync();
        void Rollback();
    }
}
