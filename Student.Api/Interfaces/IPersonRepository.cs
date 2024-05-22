using Student.Api.Models;

namespace Student.Api.Interfaces;

public interface IPersonRepository
{
    Task<bool> AddAsync(Person person);
    Task<Person> GetAsync(int id);
    Task<IEnumerable<Person>> GetAllAsync();
    Task<Person> UpdateAsync(Person person);
    Task<bool> DeleteAsync(int id);
}
