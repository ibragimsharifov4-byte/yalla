using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MenuItemRepository(AppDbContext appDbContext) : IMenuItemRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddMenuItem(MenuItem menuItem)
    {
        _context.MenuItems.Add(menuItem);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteMenuItem(int id)
    {
        var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
        if (menuItem == null)
            return false;

        _context.MenuItems.Remove(menuItem);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<MenuItem>> GetAllMenuItems()
    {
        var menuItems = await _context.MenuItems.Include(e => e.Menu).ToListAsync();
        return menuItems;
    }

    public async Task<MenuItem> GetMenuItem(int id)
    {
        var menuItem = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
        return menuItem!;
    }

    public async Task<bool> UpdateMenuItem(MenuItem menuItem, int id)
    {
        var existing = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return false;

        existing.MenuId = menuItem.MenuId;
        existing.Name = menuItem.Name;
        existing.Description = menuItem.Description;
        existing.Price = menuItem.Price;
        existing.Category = menuItem.Category;
        existing.UpdatedAt = DateTime.Now;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
