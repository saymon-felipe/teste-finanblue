using teste_finanblue.Models;

namespace teste_finanblue.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> ReturnAllUsers();
        Task<User> AddUser(User user);
        Task<User> ReturnUserByLogin(string email, string password);
    }
}
