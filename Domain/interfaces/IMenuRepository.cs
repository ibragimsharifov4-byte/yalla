using Domain.Models;

namespace Domain.interfaces;

public interface IMenuRepository
{
    Task<List<Menu>> GetAllMenus();
    Task<Menu> GetMenu(int id);
    Task<bool> AddMenu(Menu menu);
    Task<bool> UpdateMenu(Menu menu , int id);
    Task<bool> DeleteMenu(int id);
}
