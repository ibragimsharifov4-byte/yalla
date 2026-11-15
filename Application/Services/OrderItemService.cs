using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class OrderItemService(IOrderItemRepository orderItemRepository) : IOrderItemService
{
    private IOrderItemRepository _repository = orderItemRepository;
    public async Task<ApiResponse<bool>> AddOrderItem(OrderItemDto orderItem)
    {
        var model = new OrderItem
        {
            OrderId = orderItem.OrderId,
            MenuItemId = orderItem.MenuItemId,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price
        };
        var res = await _repository.AddOrderItem(model);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeleteOrderItem(int id)
    {
        var res = await _repository.DeleteOrderItem(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "OrderItem not found" , false);
    }

    public async Task<ApiResponse<List<OrderItemDto>>> GetAllOrderItems()
    {
        var res = await _repository.GetAllOrderItems();
        var list = res.Select(x => new OrderItemDto
        {
            OrderId = x.OrderId,
            MenuItemId = x.MenuItemId,
            Quantity = x.Quantity,
            Price = x.Price
        }).ToList();
        return new ApiResponse<List<OrderItemDto>>(HttpStatusCode.OK , "List of orderitems" , list);
    }

    public async Task<ApiResponse<OrderItemDto>> GetOrderItem(int id)
    {
        var res = await _repository.GetOrderItem(id);
        return res != null
        ? new ApiResponse<OrderItemDto>(HttpStatusCode.OK , "OrderItem found" , new OrderItemDto
        {
            OrderId = res.OrderId,
            MenuItemId = res.MenuItemId,
            Quantity = res.Quantity,
            Price = res.Price
        })
        : new ApiResponse<OrderItemDto>(HttpStatusCode.NotFound , "OrderItem not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateOrderItem(OrderItemDto orderItem , int id)
    {
        var model = new OrderItem
        {
            OrderId = orderItem.OrderId,
            MenuItemId = orderItem.MenuItemId,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price
        };
        var res = await _repository.UpdateOrderItem(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "OrderItem not found" , false);
    }
}
