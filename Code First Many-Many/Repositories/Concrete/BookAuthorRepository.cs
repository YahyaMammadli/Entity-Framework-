using Microsoft.EntityFrameworkCore;
using Program.Data;
using Program.Models;
using Program.Repositories.Abstract;


namespace Program.Repositories.Concrete;

public class BookAuthorRepository : IBookAuthorRepository
{
    private readonly AppDbContext _context;

    public BookAuthorRepository(AppDbContext context)
    {
        _context = context;
    }



    public BookAuthor GetById(int bookId, int authorId) => _context.BookAuthors.Find(bookId, authorId);

    public IQueryable<BookAuthor> GetAll() => _context.BookAuthors.AsNoTracking();

    public void Add(BookAuthor bookAuthor) => _context.BookAuthors.Add(bookAuthor);

    public void Update(BookAuthor bookAuthor) => _context.BookAuthors.Update(bookAuthor);

    public void Delete(int bookId, int authorId)
    {
        var ba = GetById(bookId, authorId);
        if (ba != null)
        {

            _context.BookAuthors.Remove(ba);
        }
    }

    public IQueryable<BookAuthor> GetByBookId(int bookId) 
    {
        return  _context.BookAuthors.AsNoTracking().Where(ba => ba.BookId == bookId).Include(ba => ba.Author);
    }


    public IQueryable<BookAuthor> GetByAuthorId(int authorId)
    {

      return  _context.BookAuthors.AsNoTracking().Where(ba => ba.AuthorId == authorId).Include(ba => ba.Book);
    }

    public int GetTotalContributionByAuthor(int authorId)
    {
        return _context.BookAuthors.AsNoTracking().Where(ba => ba.AuthorId == authorId).Sum(ba => ba.ContributionPercentage);

    }
}
