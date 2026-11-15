using Application.Responses;
using Application.DTOs;

namespace Application.interfaces;

public interface IMenuItemService
{
    Task<ApiResponse<List<MenuItemDto>>> GetAllMenuItems();
    Task<ApiResponse<MenuItemDto>> GetMenuItem(int id);
    Task<ApiResponse<bool>> AddMenuItem(MenuItemDto menuItem);
    Task<ApiResponse<bool>> UpdateMenuItem(MenuItemDto menuItem , int id);
    Task<ApiResponse<bool>> DeleteMenuItem(int id);
}
