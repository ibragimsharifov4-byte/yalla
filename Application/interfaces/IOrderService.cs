using Application.Responses;
using Application.DTOs;

namespace Application.interfaces;

public interface IOrderService
{
    Task<ApiResponse<List<OrderDto>>> GetAllOrders();
    Task<ApiResponse<OrderDto>> GetOrder(int id);
    Task<ApiResponse<bool>> AddOrder(OrderDto order);
    Task<ApiResponse<bool>> UpdateOrder(OrderDto order , int id);
    Task<ApiResponse<bool>> DeleteOrder(int id);
}
