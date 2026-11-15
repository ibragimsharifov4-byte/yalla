using Domain.Models;

namespace Domain.interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetAllOrders();
    Task<Order> GetOrder(int id);
    Task<bool> AddOrder(Order order);
    Task<bool> UpdateOrder(Order order , int id);
    Task<bool> DeleteOrder(int id);
}
