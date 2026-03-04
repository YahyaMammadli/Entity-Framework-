using Microsoft.EntityFrameworkCore;
using Program.Data;
using Program.Models;
using Program.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Repositories.Concrete;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }



    public Book GetById(int id) => _context.Books.Find(id);

    public IQueryable<Book> GetAll() => _context.Books.AsNoTracking();

    public void Add(Book book) => _context.Books.Add(book);

    public void Update(Book book) => _context.Books.Update(book);

    public void Delete(int id)
    {
        var book = GetById(id);
        if (book != null)
        {
            _context.Books.Remove(book);

        }
    }

    public IQueryable<Book> GetBooksWithAuthors()
    {
        return _context.Books.AsNoTracking()
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author);
    }


    public IQueryable<Book> GetBooksWithMultipleAuthors()
    {
        return _context.Books.AsNoTracking()
                .Include(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Where(b => b.BookAuthors.Count > 1);
    }


    public Book GetBookWithMostCoAuthors()
    {



        return _context.Books.AsNoTracking()
            .Include(b => b.BookAuthors)
            .OrderByDescending(b => b.BookAuthors.Count(ba => ba.Role == "CoAuthor"))
            .FirstOrDefault();
    }



}
