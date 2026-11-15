using Domain.Models;

namespace Domain.interfaces;

public interface ICompanyRepository
{
    Task<List<Company>> GetAllCompanies();
    Task<Company> GetCompany(int id);
    Task<bool> AddCompany(Company company);
    Task<bool> UpdateCompany(Company company , int id);
    Task<bool> DeleteCompany(int id);
}
