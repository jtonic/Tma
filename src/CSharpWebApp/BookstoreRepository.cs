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
        const string sql = "SELECT * FROM bookstore.authors";
        var authors = _connection.QueryAsync<Author>(sql);
        return (await authors).ToList();
    }

    public async Task<Author> AddAuthorAsync(Author author)
    {
        const string sql = "INSERT INTO  bookstore.authors (name) VALUES (@Name) RETURNING *";
        return await _connection.QuerySingleAsync<Author>(sql, author);
    }
}

public interface IBookstoreRepository
{
    Task<List<Author>> GetAuthorsAsync();
    Task<Author> AddAuthorAsync(Author author);
}