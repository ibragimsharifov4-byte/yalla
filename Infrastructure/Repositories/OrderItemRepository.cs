using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class OrderItemRepository(Database database) : IOrderItemRepository
{
    private Database _database = database;

    public async Task<bool> AddOrderItem(OrderItem orderItem)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query =
        "insert into orderitems (orderid, menuitemid, quantity, price) values (@orderid, @menuitemid, @quantity, @price)";
        var res = await connection.ExecuteAsync(query , orderItem);
        return res > 0;
    }

    public async Task<bool> DeleteOrderItem(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "delete from orderitems where id = @id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res > 0;
    }

    public async Task<List<OrderItem>> GetAllOrderItems()
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from orderitems";
        var res = await connection.QueryAsync<OrderItem>(query);
        return res.ToList();
    }

    public async Task<OrderItem> GetOrderItem(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from orderitems where id = @id";
        var res = await connection.QueryFirstOrDefaultAsync<OrderItem>(query, new {id});
        return res!;
    }

    public async Task<bool> UpdateOrderItem(OrderItem orderItem , int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "update orderitems set orderid = @orderid, menuitemid = @menuitemid, quantity = @quantity, price = @price, updatedat = current_timestamp where id = @id";
        var res = await connection.ExecuteAsync(query, new {id , orderItem.OrderId, orderItem.MenuItemId, orderItem.Quantity, orderItem.Price});
        return res > 0;
    }
}
