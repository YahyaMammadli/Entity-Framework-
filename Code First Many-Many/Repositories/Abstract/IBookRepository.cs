using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Repositories.Abstract;

public interface IBookRepository
{
    Book GetById(int id);
    IQueryable<Book> GetAll();
    void Add(Book book);
    void Update(Book book);
    void Delete(int id);
    IQueryable<Book> GetBooksWithAuthors();  
    IQueryable<Book> GetBooksWithMultipleAuthors();  
    Book GetBookWithMostCoAuthors();  
}
