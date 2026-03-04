using Program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program.Repositories.Abstract;

public interface IAuthorRepository
{
    Author GetById(int id);
    IQueryable<Author> GetAll();
    void Add(Author author);
    void Update(Author author);
    void Delete(int id);
    IQueryable<Author> GetAuthorsWithoutBooks();
    Author GetMostActiveAuthor();
    IQueryable<dynamic> GetAuthorsOrderedByBookCount();
}
