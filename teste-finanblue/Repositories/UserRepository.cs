using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using teste_finanblue.Data;
using teste_finanblue.Models;
using teste_finanblue.Repositories.Interfaces;

namespace teste_finanblue.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task<User> AddUser(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> ReturnAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> ReturnUserByLogin(string email, string password)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.email == email && x.password == password);
        }
    }
}
