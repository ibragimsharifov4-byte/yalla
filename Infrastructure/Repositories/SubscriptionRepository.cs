using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class SubscriptionRepository(Database database) : ISubscriptionRepository
{
    private Database _database = database;

    public async Task<bool> AddSubscription(Subscription subscription)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query =
        "insert into subscriptions (companyid, plantype, mealsperday, price, startdate, enddate, isactive) values (@companyid, @plantype, @mealsperday, @price, @startdate, @enddate, @isactive)";
        var res = await connection.ExecuteAsync(query , subscription);
        return res > 0;
    }

    public async Task<bool> DeleteSubscription(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "delete from subscriptions where id = @id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res > 0;
    }

    public async Task<List<Subscription>> GetAllSubscriptions()
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from subscriptions";
        var res = await connection.QueryAsync<Subscription>(query);
        return res.ToList();
    }

    public async Task<Subscription> GetSubscription(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from subscriptions where id = @id";
        var res = await connection.QueryFirstOrDefaultAsync<Subscription>(query, new {id});
        return res!;
    }

    public async Task<bool> UpdateSubscription(Subscription subscription , int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "update subscriptions set companyid = @companyid, plantype = @plantype, mealsperday = @mealsperday, price = @price, startdate = @startdate, enddate = @enddate, isactive = @isactive, updatedat = current_timestamp where id = @id";
        var res = await connection.ExecuteAsync(query, new {id , subscription.CompanyId, subscription.PlanType, subscription.MealsPerDay, subscription.Price, subscription.StartDate, subscription.EndDate, subscription.IsActive});
        return res > 0;
    }
}
