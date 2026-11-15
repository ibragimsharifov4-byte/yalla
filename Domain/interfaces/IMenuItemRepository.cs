using Domain.Models;

namespace Domain.interfaces;

public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetAllMenuItems();
    Task<MenuItem> GetMenuItem(int id);
    Task<bool> AddMenuItem(MenuItem menuItem);
    Task<bool> UpdateMenuItem(MenuItem menuItem , int id);
    Task<bool> DeleteMenuItem(int id);
}
