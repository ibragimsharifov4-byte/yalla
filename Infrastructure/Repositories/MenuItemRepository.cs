using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class MenuItemRepository(Database database) : IMenuItemRepository
{
    private Database _database = database;

    public async Task<bool> AddMenuItem(MenuItem menuItem)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query =
        "insert into menuitems (menuid, name, description, price, category) values (@menuid, @name, @description, @price, @category)";
        var res = await connection.ExecuteAsync(query , menuItem);
        return res > 0;
    }

    public async Task<bool> DeleteMenuItem(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "delete from menuitems where id = @id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res > 0;
    }

    public async Task<List<MenuItem>> GetAllMenuItems()
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from menuitems";
        var res = await connection.QueryAsync<MenuItem>(query);
        return res.ToList();
    }

    public async Task<MenuItem> GetMenuItem(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from menuitems where id = @id";
        var res = await connection.QueryFirstOrDefaultAsync<MenuItem>(query, new {id});
        return res!;
    }

    public async Task<bool> UpdateMenuItem(MenuItem menuItem , int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "update menuitems set menuid = @menuid, name = @name, description = @description, price = @price, category = @category, updatedat = current_timestamp where id = @id";
        var res = await connection.ExecuteAsync(query, new {id , menuItem.MenuId, menuItem.Name, menuItem.Description, menuItem.Price, menuItem.Category});
        return res > 0;
    }
}
