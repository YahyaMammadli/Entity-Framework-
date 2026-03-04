using Microsoft.EntityFrameworkCore;
using Program.Data;
using Program.Models;
using Program.Repositories.Abstract;


namespace Program.Repositories.Concrete;

public class AuthorRepository : IAuthorRepository
{
    private readonly AppDbContext _context;

    public AuthorRepository(AppDbContext context)
    {
        _context = context;
    }


    public Author GetById(int id) => _context.Authors.Find(id);

    public IQueryable<Author> GetAll() => _context.Authors.AsNoTracking();

    public void Add(Author author) => _context.Authors.Add(author);

    public void Update(Author author) => _context.Authors.Update(author);

    public void Delete(int id)
    {
        var author = GetById(id);
        if (author != null)
        {
            _context.Authors.Remove(author);

        }

    }

    public IQueryable<Author> GetAuthorsWithoutBooks()
    {
        return _context.Authors.AsNoTracking().Where(a => !a.BookAuthors.Any());

    }

    public Author GetMostActiveAuthor()
    {


        return _context.Authors.AsNoTracking().Include(a => a.BookAuthors)
                .OrderByDescending(a => a.BookAuthors.Count)
                .FirstOrDefault();
    }



    public IQueryable<dynamic> GetAuthorsOrderedByBookCount()
    {
        return _context.Authors.AsNoTracking()
             .Select(a => new
             {
                 a.FirstName,
                 a.LastName,
                 BookCount = a.BookAuthors.Count
             })
             .OrderByDescending(x => x.BookCount)
             .ThenBy(x => x.LastName);
        

    }
}
