using Domain.interfaces;
using Application.DTOs;
using Application.interfaces;
using Application.Responses;
using Domain.Models;
using System.Net;

namespace Application.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    private IOrderRepository _repository = orderRepository;
    public async Task<ApiResponse<bool>> AddOrder(OrderDto order)
    {
        var model = new Order
        {
            CompanyId = order.CompanyId,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount
        };
        var res = await _repository.AddOrder(model);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added(" , false);
    }

    public async Task<ApiResponse<bool>> DeleteOrder(int id)
    {
        var res = await _repository.DeleteOrder(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "Order not found" , false);
    }

    public async Task<ApiResponse<List<OrderDto>>> GetAllOrders()
    {
        var res = await _repository.GetAllOrders();
        var list = res.Select(x => new OrderDto
        {
            CompanyId = x.CompanyId,
            OrderDate = x.OrderDate,
            Status = x.Status,
            TotalAmount = x.TotalAmount
        }).ToList();
        return new ApiResponse<List<OrderDto>>(HttpStatusCode.OK , "List of orders" , list);
    }

    public async Task<ApiResponse<OrderDto>> GetOrder(int id)
    {
        var res = await _repository.GetOrder(id);
        return res != null
        ? new ApiResponse<OrderDto>(HttpStatusCode.OK , "Order found" , new OrderDto
        {
            CompanyId = res.CompanyId,
            OrderDate = res.OrderDate,
            Status = res.Status,
            TotalAmount = res.TotalAmount
        })
        : new ApiResponse<OrderDto>(HttpStatusCode.NotFound , "Order not found" , null);
    }

    public async Task<ApiResponse<bool>> UpdateOrder(OrderDto order , int id)
    {
        var model = new Order
        {
            CompanyId = order.CompanyId,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount
        };
        var res = await _repository.UpdateOrder(model , id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.NotFound , "Order not found" , false);
    }
}
