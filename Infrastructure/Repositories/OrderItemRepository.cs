using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderItemRepository(AppDbContext appDbContext) : IOrderItemRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddOrderItem(OrderItem orderItem)
    {
        _context.OrderItems.Add(orderItem);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteOrderItem(int id)
    {
        var orderItem = await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
        if (orderItem == null)
            return false;

        _context.OrderItems.Remove(orderItem);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<OrderItem>> GetAllOrderItems()
    {
        var orderItems = await _context.OrderItems.Include(e => e.Order).Include(e => e.MenuItem).ToListAsync();
        return orderItems;
        
    }

    public async Task<OrderItem> GetOrderItem(int id)
    {
        var orderItem = await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
        return orderItem!;
    }

    public async Task<bool> UpdateOrderItem(OrderItem orderItem, int id)
    {
        var existing = await _context.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return false;

        existing.OrderId = orderItem.OrderId;
        existing.MenuItemId = orderItem.MenuItemId;
        existing.Quantity = orderItem.Quantity;
        existing.Price = orderItem.Price;
        existing.UpdatedAt = DateTime.Now;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
