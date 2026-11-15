using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    private IOrderService _service = orderService;

    [HttpGet]
    public async Task<ApiResponse<List<OrderDto>>> GetAllOrders()
    {
        return await _service.GetAllOrders();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<OrderDto>> GetOrder(int id)
    {
        return await _service.GetOrder(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddOrder(OrderDto order)
    {
        return await _service.AddOrder(order);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteOrder(int id)
    {
        return await _service.DeleteOrder(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateOrder(OrderDto order , int id)
    {
        return await _service.UpdateOrder(order , id);
    }
}
