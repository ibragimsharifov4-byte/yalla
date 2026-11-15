using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuController(IMenuService menuService) : ControllerBase
{
    private IMenuService _service = menuService;

    [HttpGet]
    public async Task<ApiResponse<List<MenuDto>>> GetAllMenus()
    {
        return await _service.GetAllMenus();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<MenuDto>> GetMenu(int id)
    {
        return await _service.GetMenu(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMenu(MenuDto menu)
    {
        return await _service.AddMenu(menu);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMenu(int id)
    {
        return await _service.DeleteMenu(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateMenu(MenuDto menu , int id)
    {
        return await _service.UpdateMenu(menu , id);
    }
}
