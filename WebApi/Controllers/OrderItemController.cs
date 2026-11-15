using Application.interfaces;
using Application.DTOs;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController(IOrderItemService orderItemService) : ControllerBase
{
    private IOrderItemService _service = orderItemService;

    [HttpGet]
    public async Task<ApiResponse<List<OrderItemDto>>> GetAllOrderItems()
    {
        return await _service.GetAllOrderItems();
    }

    [HttpGet("{id}")]
    public async Task<ApiResponse<OrderItemDto>> GetOrderItem(int id)
    {
        return await _service.GetOrderItem(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddOrderItem(OrderItemDto orderItem)
    {
        return await _service.AddOrderItem(orderItem);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteOrderItem(int id)
    {
        return await _service.DeleteOrderItem(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateOrderItem(OrderItemDto orderItem , int id)
    {
        return await _service.UpdateOrderItem(orderItem , id);
    }
}
