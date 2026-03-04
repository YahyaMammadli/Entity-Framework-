using Program.Models;


namespace Program.Repositories.Abstract;

public interface IBookAuthorRepository
{
    BookAuthor GetById(int bookId, int authorId);
    IQueryable<BookAuthor> GetAll();
    void Add(BookAuthor bookAuthor);
    void Update(BookAuthor bookAuthor);
    void Delete(int bookId, int authorId);
    IQueryable<BookAuthor> GetByBookId(int bookId);
    IQueryable<BookAuthor> GetByAuthorId(int authorId);
    int GetTotalContributionByAuthor(int authorId);
}
