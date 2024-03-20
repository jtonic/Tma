namespace CSharpWebApp;

using Dapper;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BookstoreRepository : IBookstoreRepository
{
    private readonly NpgsqlConnection _connection = new("Host=localhost;Username=postgres;Password=admin;Database=postgres");

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