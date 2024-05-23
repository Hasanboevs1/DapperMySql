# DapperMySql

DapperMySql is a lightweight and high-performance data access library for MySQL, utilizing the power and simplicity of Dapper. Designed to work seamlessly with MySQL databases, DapperMySql simplifies database interactions by providing an easy-to-use interface for executing queries and mapping results to strongly-typed objects.

## Features

- **Lightweight and Fast**: Built on top of Dapper, it provides minimal overhead and maximum performance.
- **Simple API**: Intuitive and easy-to-use methods for executing SQL queries and commands.
- **Strong Typing**: Maps database results to strongly-typed C# objects, reducing errors and improving code readability.
- **Support for Stored Procedures**: Easily execute stored procedures with input and output parameters.
- **Parameterized Queries**: Helps prevent SQL injection attacks by using parameterized queries.
- **Async Support**: Fully supports asynchronous operations, making it suitable for modern, high-performance applications.


## Usage

### Setting Up the Connection

First, create a MySQL connection using `MySqlConnection`:

```csharp
using MySql.Data.MySqlClient;
using Dapper;

string connectionString = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;";
using (MySqlConnection connection = new MySqlConnection(connectionString))
{
    connection.Open();
    // Your code here
}
```

### Querying Data

Use DapperMySql to execute queries and map results to your C# classes:

```csharp
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

string sql = "SELECT Id, Name, Email FROM Users";
var users = connection.Query<User>(sql).ToList();
```

### Executing Commands

Insert, update, and delete operations are just as straightforward:

```csharp
string insertSql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
var parameters = new { Name = "John Doe", Email = "john.doe@example.com" };
int rowsAffected = connection.Execute(insertSql, parameters);
```

### Using Stored Procedures

Executing stored procedures with DapperMySql is simple and efficient:

```csharp
var parameters = new { UserId = 1 };
var user = connection.QueryFirstOrDefault<User>("GetUserById", parameters, commandType: CommandType.StoredProcedure);
```

## Contributing

Contributions are welcome! If you find a bug or want to add a new feature, please open an issue or submit a pull request. Make sure to follow the guidelines outlined in the [CONTRIBUTING.md](CONTRIBUTING.md) file.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgements

Special thanks to the Dapper and MySQL communities for their continuous support and contributions to the ecosystem.

## Author

This project is maintained by [Hasanboevs]. You can find more about me and my other projects on my [personal website](https://hasanboevs.netlify.app).

---

With DapperMySql, you get the best of both worlds: the simplicity and speed of Dapper combined with the power of MySQL. Start building your high-performance data access layer today!
