using API_Transferencias.Data;
using API_Transferencias.Interfaces;
using API_Transferencias.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Transferencias.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public async Task<User> DeleteUser(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            return user;
        }

        public async Task<User> ResgisterAsync(User user)
        {
            await _context.Set<User>().AddAsync(user);
            return user;
        }
    }
}
