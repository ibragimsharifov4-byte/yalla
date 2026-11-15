using Application.Responses;
using Application.DTOs;

namespace Application.interfaces;

public interface IOrderItemService
{
    Task<ApiResponse<List<OrderItemDto>>> GetAllOrderItems();
    Task<ApiResponse<OrderItemDto>> GetOrderItem(int id);
    Task<ApiResponse<bool>> AddOrderItem(OrderItemDto orderItem);
    Task<ApiResponse<bool>> UpdateOrderItem(OrderItemDto orderItem , int id);
    Task<ApiResponse<bool>> DeleteOrderItem(int id);
}
