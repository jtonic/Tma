namespace CSharpWebApp;

public class BookstoreService: IBookstoreService
{
    private readonly IBookstoreRepository _bookstoreRepository;

    public BookstoreService(IBookstoreRepository bookstoreRepository)
    {
        _bookstoreRepository = bookstoreRepository;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        return await _bookstoreRepository.GetAuthorsAsync();
    }
}

public interface IBookstoreService
{
    Task<List<Author>> GetAuthorsAsync();
}
