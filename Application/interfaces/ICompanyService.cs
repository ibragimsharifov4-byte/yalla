using Application.Responses;
using Application.DTOs;

namespace Application.interfaces;

public interface ICompanyService
{
    Task<ApiResponse<List<CompanyDto>>> GetAllCompanies();
    Task<ApiResponse<CompanyDto>> GetCompany(int id);
    Task<ApiResponse<bool>> AddCompany(CompanyDto company);
    Task<ApiResponse<bool>> UpdateCompany(CompanyDto company , int id);
    Task<ApiResponse<bool>> DeleteCompany(int id);
}
