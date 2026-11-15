using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class OrderRepository(Database database) : IOrderRepository
{
    private Database _database = database;

    public async Task<bool> AddOrder(Order order)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query =
        "insert into orders (companyid, orderdate, status, totalamount) values (@companyid, @orderdate, @status, @totalamount)";
        var res = await connection.ExecuteAsync(query , order);
        return res > 0;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "delete from orders where id = @id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res > 0;
    }

    public async Task<List<Order>> GetAllOrders()
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from orders";
        var res = await connection.QueryAsync<Order>(query);
        return res.ToList();
    }

    public async Task<Order> GetOrder(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from orders where id = @id";
        var res = await connection.QueryFirstOrDefaultAsync<Order>(query, new {id});
        return res!;
    }

    public async Task<bool> UpdateOrder(Order order , int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "update orders set companyid = @companyid, orderdate = @orderdate, status = @status, totalamount = @totalamount, updatedat = current_timestamp where id = @id";
        var res = await connection.ExecuteAsync(query, new {id , order.CompanyId, order.OrderDate, order.Status, order.TotalAmount});
        return res > 0;
    }
}
