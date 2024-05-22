using Dapper;
using MySql.Data.MySqlClient;
using Student.Api.Interfaces;
using System.Data;

namespace Student.Api.Reposiotries;

public class DbService : IDbService
{
    private readonly IDbConnection _db;
    public DbService(IConfiguration config)
    {
        _db = new MySqlConnection(config.GetConnectionString("DefaultString"));
    }
    public async Task<int> EditData(string command, object parms)
    {
        int result = await _db.ExecuteAsync(command, parms);
        return result;
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>(string command, object parms)
    {
        IEnumerable<T> result = (await _db.QueryAsync<T>(command, parms)).ToList();
        return result;
    }

    public async Task<T> GetAsync<T>(string command, object parms)
    {
        T result =  (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault()?? throw new Exception("Something went wrong");
        return result;
    }
}
