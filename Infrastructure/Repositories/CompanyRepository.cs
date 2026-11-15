using Domain.Data;
using Domain.interfaces;
using Domain.Models;
using Dapper;

namespace Infrastructure.Repositories;

public class CompanyRepository(Database database) : ICompanyRepository
{
    private Database _database = database;

    public async Task<bool> AddCompany(Company company)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query =
        "insert into companies (name, address, phone, email) values (@name, @address, @phone, @email)";
        var res = await connection.ExecuteAsync(query , company);
        return res > 0;
    }

    public async Task<bool> DeleteCompany(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "delete from companies where id = @id";
        var res = await connection.ExecuteAsync(query, new {id});
        return res > 0;
    }

    public async Task<List<Company>> GetAllCompanies()
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from companies";
        var res = await connection.QueryAsync<Company>(query);
        return res.ToList();
    }

    public async Task<Company> GetCompany(int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "select * from companies where id = @id";
        var res = await connection.QueryFirstOrDefaultAsync<Company>(query, new {id});
        return res!;
    }

    public async Task<bool> UpdateCompany(Company company , int id)
    {
        using var connection = _database.Connection();
        connection.Open();
        var query = "update companies set name = @name, address = @address, phone = @phone, email = @email, updatedat = current_timestamp where id = @id";
        var res = await connection.ExecuteAsync(query, new {id , company.Name, company.Address, company.Phone, company.Email});
        return res > 0;
    }
}
