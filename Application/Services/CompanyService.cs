using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    private ICompanyRepository _repository = companyRepository;
    public async Task<ApiResponse<bool>> AddCompany(CompanyDto company)
    {
        var model = new Company
        {
            Name = company.Name,
            Address = company.Address,
            Phone = company.Phone,
            Email = company.Email
        };
        var res = await _repository.AddCompany(model);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeleteCompany(int id)
    {
        var res = await _repository.DeleteCompany(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "Company not found" , false);
    }

    public async Task<ApiResponse<List<CompanyDto>>> GetAllCompanies()
    {
        var res = await _repository.GetAllCompanies();
        var list = res.Select(x => new CompanyDto
        {
            Name = x.Name,
            Address = x.Address,
            Phone = x.Phone,
            Email = x.Email
        }).ToList();
        return new ApiResponse<List<CompanyDto>>(HttpStatusCode.OK , "List of companies" , list);
    }

    public async Task<ApiResponse<CompanyDto>> GetCompany(int id)
    {
        var res = await _repository.GetCompany(id);
        return res != null
        ? new ApiResponse<CompanyDto>(HttpStatusCode.OK , "Company found" , new CompanyDto
        {
            Name = res.Name,
            Address = res.Address,
            Phone = res.Phone,
            Email = res.Email
        })
        : new ApiResponse<CompanyDto>(HttpStatusCode.NotFound , "Company not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateCompany(CompanyDto company , int id)
    {
        var model = new Company
        {
            Name = company.Name,
            Address = company.Address,
            Phone = company.Phone,
            Email = company.Email
        };
        var res = await _repository.UpdateCompany(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "Company not found" , false);
    }
}
