using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class MenuRepository(Database database) : IMenuRepository
{
    private Database _database = database;

    public async Task<bool> AddMenu(Menu menu)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query =
        "insert into menus (menudate, isactive) values (@menudate, @isactive)";
        var res = await connection.ExecuteAsync(query , menu);
        return res > 0;
    }

    public async Task<bool> DeleteMenu(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "delete from menus where id = @id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res > 0;
    }

    public async Task<List<Menu>> GetAllMenus()
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from menus";
        var res = await connection.QueryAsync<Menu>(query);
        return res.ToList();
    }

    public async Task<Menu> GetMenu(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from menus where id = @id";
        var res = await connection.QueryFirstOrDefaultAsync<Menu>(query, new {id});
        return res!;
    }

    public async Task<bool> UpdateMenu(Menu menu , int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "update menus set menudate = @menudate, isactive = @isactive, updatedat = current_timestamp where id = @id";
        var res = await connection.ExecuteAsync(query, new {id , menu.MenuDate, menu.IsActive});
        return res > 0;
    }
}
