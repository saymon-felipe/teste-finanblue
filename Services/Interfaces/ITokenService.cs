using teste_finanblue.Models;

namespace teste_finanblue.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
