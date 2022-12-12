using Microsoft.EntityFrameworkCore;
using teste_finanblue.Data;
using teste_finanblue.Models;
using teste_finanblue.Repositories.Interfaces;

namespace teste_finanblue.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDBContext _dbContext;
        public CompanyRepository(AppDBContext appDBContext)
        {
            _dbContext = appDBContext;
        }
        public async Task<Company> AddCompany(Company company)
        {
            await _dbContext.Companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();

            return company;
        }

        public async Task<List<Company>> ReturnAllCompanies()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        public async Task<Company> ReturnCompanyById(int companyId)
        {
            return await _dbContext.Companies.FirstOrDefaultAsync(x => x.id == companyId);
        }

        public async Task<Company> SetCreatorId(Company company, int creatorId)
        {
            Company companyById = await ReturnCompanyById(company.id);

            if (companyById == null)
            {
                throw new Exception("Empresa não encontrada");
            }

            companyById.setCompanyCreator(creatorId);
            _dbContext.Companies.Update(companyById);
            _dbContext.SaveChanges();

            return companyById;
        }
    }
}
