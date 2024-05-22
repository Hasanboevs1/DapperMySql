namespace Student.Api.Interfaces;

public interface IDbService
{
    Task<T> GetAsync<T>(string command, object parms);
    Task<IEnumerable<T>> GetAllAsync<T>(string command, object parms);
    Task<int> EditData(string command, object parms);   
}
