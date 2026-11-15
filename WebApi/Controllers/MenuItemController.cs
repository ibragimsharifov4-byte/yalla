using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuItemController(IMenuItemService menuItemService) : ControllerBase
{
    private IMenuItemService _service = menuItemService;

    [HttpGet]
    public async Task<ApiResponse<List<MenuItemDto>>> GetAllMenuItems()
    {
        return await _service.GetAllMenuItems();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<MenuItemDto>> GetMenuItem(int id)
    {
        return await _service.GetMenuItem(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMenuItem(MenuItemDto menuItem)
    {
        return await _service.AddMenuItem(menuItem);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMenuItem(int id)
    {
        return await _service.DeleteMenuItem(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateMenuItem(MenuItemDto menuItem , int id)
    {
        return await _service.UpdateMenuItem(menuItem , id);
    }
}
