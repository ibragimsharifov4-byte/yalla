using Domain.interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MenuRepository(AppDbContext appDbContext) : IMenuRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddMenu(Menu menu)
    {
        _context.Menus.Add(menu);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteMenu(int id)
    {
        var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);
        if (menu == null)
            return false;

        _context.Menus.Remove(menu);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<Menu>> GetAllMenus()
    {
        return await _context.Menus.ToListAsync();
    }

    public async Task<Menu> GetMenu(int id)
    {
        var menu = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);
        return menu!;
    }

    public async Task<bool> UpdateMenu(Menu menu, int id)
    {
        var existing = await _context.Menus.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return false;

        existing.MenuDate = menu.MenuDate;
        existing.IsActive = menu.IsActive;
        existing.UpdatedAt = DateTime.Now;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
