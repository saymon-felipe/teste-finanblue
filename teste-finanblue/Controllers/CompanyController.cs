using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teste_finanblue.Models;
using teste_finanblue.Repositories;
using teste_finanblue.Repositories.Interfaces;

namespace teste_finanblue.Controllers
{
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet("/companies")]
        public async Task<ActionResult<List<Company>>> ReturnAllCompanies()
        {
            List<Company> companies = await _companyRepository.ReturnAllCompanies();
            return Ok(companies);
        }

        [HttpPost("/companies")]
        [Authorize]
        public async Task<ActionResult<Company>> AddCompany([FromBody] Company companyModel)
        {
            int creatorId = Int32.Parse(HttpContext.User.Claims.ElementAt(2).Value);
            Company company = await _companyRepository.AddCompany(companyModel);
            Company newCompany = await _companyRepository.SetCreatorId(company, creatorId);
            return Ok(newCompany);
        }
    }
}
