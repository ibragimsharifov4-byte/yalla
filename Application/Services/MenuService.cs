using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class MenuService(IMenuRepository menuRepository) : IMenuService
{
    private IMenuRepository _repository = menuRepository;
    public async Task<ApiResponse<bool>> AddMenu(MenuDto menu)
    {
        var model = new Menu
        {
            MenuDate = menu.MenuDate,
            IsActive = menu.IsActive
        };
        var res = await _repository.AddMenu(model);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeleteMenu(int id)
    {
        var res = await _repository.DeleteMenu(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "Menu not found" , false);
    }

    public async Task<ApiResponse<List<MenuDto>>> GetAllMenus()
    {
        var res = await _repository.GetAllMenus();
        var list = res.Select(x => new MenuDto
        {
            MenuDate = x.MenuDate,
            IsActive = x.IsActive
        }).ToList();
        return new ApiResponse<List<MenuDto>>(HttpStatusCode.OK , "List of menus" , list);
    }

    public async Task<ApiResponse<MenuDto>> GetMenu(int id)
    {
        var res = await _repository.GetMenu(id);
        return res != null
        ? new ApiResponse<MenuDto>(HttpStatusCode.OK , "Menu found" , new MenuDto
        {
            MenuDate = res.MenuDate,
            IsActive = res.IsActive
        })
        : new ApiResponse<MenuDto>(HttpStatusCode.NotFound , "Menu not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateMenu(MenuDto menu , int id)
    {
        var model = new Menu
        {
            MenuDate = menu.MenuDate,
            IsActive = menu.IsActive
        };
        var res = await _repository.UpdateMenu(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "Menu not found" , false);
    }
}
