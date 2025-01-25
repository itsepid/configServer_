using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConfigServer.Domain.Entities;
using ConfigServer.Application.Interfaces;

namespace ConfigServer.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByIdAsync(int Id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
