using CSharpWebApp.Exceptions;
using Dapper;
using Npgsql;

namespace CSharpWebApp;

public class BookstoreRepository : IBookstoreRepository
{
    
    private readonly NpgsqlConnection _connection;

    public BookstoreRepository(IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("BookstoreDatabase") ?? throw new ConfigurationKeyNotFoundException("BookstoreDatabase");
        _connection = new(connectionString);
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        const string sql = "SELECT * FROM bookstore.Authors";
        var authors = _connection.QueryAsync<Author>(sql);
        return (await authors).ToList();
    }
}

public interface IBookstoreRepository
{
    Task<List<Author>> GetAuthorsAsync();
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
}