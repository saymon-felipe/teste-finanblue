using teste_finanblue.Models;

namespace teste_finanblue.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> ReturnAllCompanies();
        Task<Company> AddCompany(Company company);
        Task<Company> SetCreatorId(Company company, int creatorId);
    }
}
