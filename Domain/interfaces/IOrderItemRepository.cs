using Domain.Models;

namespace Domain.interfaces;

public interface IOrderItemRepository
{
    Task<List<OrderItem>> GetAllOrderItems();
    Task<OrderItem> GetOrderItem(int id);
    Task<bool> AddOrderItem(OrderItem orderItem);
    Task<bool> UpdateOrderItem(OrderItem orderItem , int id);
    Task<bool> DeleteOrderItem(int id);
}
