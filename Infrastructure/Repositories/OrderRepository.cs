using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository(AppDbContext appDbContext) : IOrderRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddOrder(Order order)
    {
        _context.Orders.Add(order);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        if (order == null)
            return false;

        _context.Orders.Remove(order);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<Order>> GetAllOrders()
    {
        var orders = await _context.Orders.Include(e => e.Company).ToListAsync();
        return orders;
    }

    public async Task<Order> GetOrder(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        return order!;
    }

    public async Task<bool> UpdateOrder(Order order, int id)
    {
        var existing = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return false;

        existing.CompanyId = order.CompanyId;
        existing.OrderDate = order.OrderDate;
        existing.Status = order.Status;
        existing.TotalAmount = order.TotalAmount;
        existing.UpdatedAt = DateTime.Now;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
