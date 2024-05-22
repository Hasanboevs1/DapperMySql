using Student.Api.Interfaces;
using Student.Api.Models;

namespace Student.Api.Reposiotries;

public class PersonRepository : IPersonRepository
{
    private readonly IDbService _db;
    public PersonRepository(IDbService db)
    {
        _db = db;
    }
    public async Task<bool> AddAsync(Person person)
    {
        var result =
            await _db.EditData(
                "insert into Person(Id, Name, Email) values (@id, @Name, @Email)", person );
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var deletedID = await _db.EditData("delete from Person where  id = @Id", new { id });
        return true;
    }

    public async Task<IEnumerable<Person>> GetAllAsync()
    {
        var people = await _db.GetAllAsync<Person>("select * from Person", new {});
        return people;
    }

    public async Task<Person> GetAsync(int id)
    {
        var person = await _db.GetAsync<Person>("select * from Person where id = @Id", new { id }); 
        return person;
    }

    public async Task<Person> UpdateAsync(Person person)
    {
        var updatedID =
            await _db.EditData(
                "update Person set Name = @Name, Email = @Email where id = @Id", person );
        return person;
    }
}
