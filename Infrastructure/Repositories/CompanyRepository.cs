using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CompanyRepository(AppDbContext appDbContext) : ICompanyRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddCompany(Company company)
    {
        _context.Companies.Add(company);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteCompany(int id)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (company == null)
            return false;

        _context.Companies.Remove(company);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<Company>> GetAllCompanies()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company> GetCompany(int id)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        return company!;
    }

    public async Task<bool> UpdateCompany(Company company, int id)
    {
        var existing = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return false;

        existing.Name = company.Name;
        existing.Address = company.Address;
        existing.Phone = company.Phone;
        existing.Email = company.Email;
        existing.UpdatedAt = DateTime.Now;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
