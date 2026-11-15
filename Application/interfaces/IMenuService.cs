using Application.Responses;
using Application.DTOs;

namespace Application.interfaces;

public interface IMenuService
{
    Task<ApiResponse<List<MenuDto>>> GetAllMenus();
    Task<ApiResponse<MenuDto>> GetMenu(int id);
    Task<ApiResponse<bool>> AddMenu(MenuDto menu);
    Task<ApiResponse<bool>> UpdateMenu(MenuDto menu , int id);
    Task<ApiResponse<bool>> DeleteMenu(int id);
}
