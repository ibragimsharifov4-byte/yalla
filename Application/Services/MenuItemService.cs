using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class MenuItemService(IMenuItemRepository menuItemRepository) : IMenuItemService
{
    private IMenuItemRepository _repository = menuItemRepository;
    public async Task<ApiResponse<bool>> AddMenuItem(MenuItemDto menuItem)
    {
        var model = new MenuItem
        {
            MenuId = menuItem.MenuId,
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            Category = menuItem.Category
        };
        var res = await _repository.AddMenuItem(model);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeleteMenuItem(int id)
    {
        var res = await _repository.DeleteMenuItem(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "MenuItem not found" , false);
    }

    public async Task<ApiResponse<List<MenuItemDto>>> GetAllMenuItems()
    {
        var res = await _repository.GetAllMenuItems();
        var list = res.Select(x => new MenuItemDto
        {
            MenuId = x.MenuId,
            Name = x.Name,
            Description = x.Description,
            Price = x.Price,
            Category = x.Category
        }).ToList();
        return new ApiResponse<List<MenuItemDto>>(HttpStatusCode.OK , "List of menuitems" , list);
    }

    public async Task<ApiResponse<MenuItemDto>> GetMenuItem(int id)
    {
        var res = await _repository.GetMenuItem(id);
        return res != null
        ? new ApiResponse<MenuItemDto>(HttpStatusCode.OK , "MenuItem found" , new MenuItemDto
        {
            MenuId = res.MenuId,
            Name = res.Name,
            Description = res.Description,
            Price = res.Price,
            Category = res.Category
        })
        : new ApiResponse<MenuItemDto>(HttpStatusCode.NotFound , "MenuItem not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateMenuItem(MenuItemDto menuItem , int id)
    {
        var model = new MenuItem
        {
            MenuId = menuItem.MenuId,
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            Category = menuItem.Category
        };
        var res = await _repository.UpdateMenuItem(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "MenuItem not found" , false);
    }
}
