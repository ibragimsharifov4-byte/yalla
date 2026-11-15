using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController(ICompanyService companyService) : ControllerBase
{
    private ICompanyService _service = companyService;

    [HttpGet]
    public async Task<ApiResponse<List<CompanyDto>>> GetAllCompanies()
    {
        return await _service.GetAllCompanies();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<CompanyDto>> GetCompany(int id)
    {
        return await _service.GetCompany(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddCompany(CompanyDto company)
    {
        return await _service.AddCompany(company);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCompany(int id)
    {
        return await _service.DeleteCompany(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCompany(CompanyDto company , int id)
    {
        return await _service.UpdateCompany(company , id);
    }
}
