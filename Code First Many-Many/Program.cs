using Program.Data;
using Program.Models;
using Program.Repositories.Concrete;


namespace Program;

class Program
{
    
    
    
    static void Main()
    {

        using (var context = new AppDbContext())
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var authorRepo = new AuthorRepository(context);
            
            var bookRepo = new BookRepository(context);
            
            var bookAuthorRepo = new BookAuthorRepository(context);


            
            Console.Write("Adding additional test data...\n");


            
            var tolkien = new Author { FirstName = "J.R.R.", LastName = "Tolkien", Email = "tolkien@books.com" };
            
            var tolstoy = new Author { FirstName = "Leo", LastName = "Tolstoy", Email = "tolstoy@books.com" };
            
            var twain = new Author { FirstName = "Mark", LastName = "Twain", Email = "twain@books.com" };
            
            var hemingway = new Author { FirstName = "Ernest", LastName = "Hemingway", Email = "hemingway@books.com" }; 




            
            authorRepo.Add(tolkien);
            
            authorRepo.Add(tolstoy);
            
            authorRepo.Add(twain);
            
            authorRepo.Add(hemingway);
            
            context.SaveChanges();


            var lotr = new Book { Title = "The Lord of the Rings", Description = "Epic fantasy", Price = 30m };
            
            var warAndPeace = new Book { Title = "War and Peace", Description = "Historical novel", Price = 28m };
            
            var adventuresHuck = new Book { Title = "Adventures of Huckleberry Finn", Description = "Satirical novel", Price = 15m };
            
            var silmarillion = new Book { Title = "The Silmarillion", Description = "Mythopoeia", Price = 22m };
            
            var threeAuthorsBook = new Book { Title = "Collaborative Novel", Description = "Written by three co-authors", Price = 25m };

            
            bookRepo.Add(lotr);
            
            bookRepo.Add(warAndPeace);
            
            bookRepo.Add(adventuresHuck);
            
            bookRepo.Add(silmarillion);
            
            bookRepo.Add(threeAuthorsBook);
            
            context.SaveChanges();

            bookAuthorRepo.Add(new BookAuthor
            {
                BookId = lotr.Id,
                AuthorId = tolkien.Id,
                Role = "MainAuthor",
                ContributionPercentage = 100,
                AddedAt = DateTime.Now
            });
            
            bookAuthorRepo.Add(new BookAuthor
            {
                BookId = silmarillion.Id,
                AuthorId = tolkien.Id,
                Role = "MainAuthor",
                ContributionPercentage = 100,
                AddedAt = DateTime.Now
            });

            
            bookAuthorRepo.Add(new BookAuthor
            {
                BookId = warAndPeace.Id,
                AuthorId = tolstoy.Id,
                Role = "MainAuthor",
                ContributionPercentage = 100,
                AddedAt = DateTime.Now
            });

            
            
            bookAuthorRepo.Add(new BookAuthor
            {
                BookId = adventuresHuck.Id,
                AuthorId = twain.Id,
                Role = "MainAuthor",
                ContributionPercentage = 100,
                AddedAt = DateTime.Now
            });

            
            
            bookAuthorRepo.Add(new BookAuthor
            {
                BookId = threeAuthorsBook.Id,
                AuthorId = tolkien.Id,
                Role = "CoAuthor",
                ContributionPercentage = 33,
                AddedAt = DateTime.Now
            });
            
            
            bookAuthorRepo.Add(new BookAuthor
            {
                BookId = threeAuthorsBook.Id,
                AuthorId = tolstoy.Id,
                Role = "CoAuthor",
                ContributionPercentage = 33,
                AddedAt = DateTime.Now
            });
            
            
            bookAuthorRepo.Add(new BookAuthor
            {
                BookId = threeAuthorsBook.Id,
                AuthorId = twain.Id,
                Role = "CoAuthor",
                ContributionPercentage = 34,
                AddedAt = DateTime.Now
            });


            context.SaveChanges();

            Console.Write("Additional test data added.\n\n");

            Console.Write("1. Adding a book with a new author by Id:\n");
            
            
            var newAuthor1 = new Author { FirstName = "Stephen", LastName = "King", Email = "stephen@books.com" };
            
            authorRepo.Add(newAuthor1);
            
            context.SaveChanges();

            var newBook1 = new Book { Title = "The Shining", Description = "Horror novel", Price = 22m };
            
            
            bookRepo.Add(newBook1);
            
            context.SaveChanges();

            var bookAuthor1 = new BookAuthor
            {
                BookId = newBook1.Id,
                AuthorId = newAuthor1.Id,
                Role = "MainAuthor",
                ContributionPercentage = 100,
                AddedAt = DateTime.Now
            };
            
            bookAuthorRepo.Add(bookAuthor1);
            
            context.SaveChanges();
            
            Console.Write("   Book and author added.\n\n");







            Console.Write("2. Adding a book with a new author through navigation properties:\n");
            
            var newAuthor2 = new Author { FirstName = "Stephen", LastName = "King", Email = "stephen@books.com" };
            
            var newBook2 = new Book
            {
                Title = "It",
                Description = "Horror novel about clown",
                Price = 25m,
                BookAuthors = new List<BookAuthor>
                {
                    new BookAuthor
                    {
                        Author = newAuthor2,
                        Role = "MainAuthor",
                        ContributionPercentage = 100,
                        AddedAt = DateTime.Now
                    }
                }
            };

            
            bookRepo.Add(newBook2);
            
            context.SaveChanges();
            
            Console.Write("   Book and author added.\n\n");


            Console.Write("3. All books with authors:\n");
            
            var booksWithAuthors = bookRepo.GetBooksWithAuthors().ToList();
            
            foreach (var book in booksWithAuthors)
            {
                Console.Write($"Book: {book.Title}, Price: {book.Price:C}\n");
            
                foreach (var ba in book.BookAuthors)
                {
                    Console.Write($"  Author: {ba.Author.FirstName} {ba.Author.LastName}, Role: {ba.Role}, Contribution: {ba.ContributionPercentage}%\n");
                }
            }

            Console.Write("\n");




            Console.Write("4. Book titles and author names:\n");
            
            
            var titlesAndAuthors = context.BookAuthors
                .Select(ba => new { BookTitle = ba.Book.Title, AuthorName = ba.Author.FirstName + " " + ba.Author.LastName })
                .Distinct()
                .ToList();
            
            foreach (var item in titlesAndAuthors)
            {
                Console.Write($"Book: {item.BookTitle}, Author: {item.AuthorName}\n");
            }
            
            Console.Write("\n");

            
            Console.Write("5. Authors without books:\n");
            
            var authorsWithoutBooks = authorRepo.GetAuthorsWithoutBooks().ToList();
            
            if (authorsWithoutBooks.Any())
            {
                foreach (var a in authorsWithoutBooks)
                {
                    Console.Write($"{a.FirstName} {a.LastName}\n");
                }
            }
            
            else
            {
                Console.Write("   No authors without books.\n");
            }
            
            Console.Write("\n");

            Console.Write("6. Books with more than one author:\n");
            
            var multiAuthorBooks = bookRepo.GetBooksWithMultipleAuthors().ToList();
            
            foreach (var book in multiAuthorBooks)
            {
                Console.Write($"Book: {book.Title}, Number of authors: {book.BookAuthors.Count}\n");
            }
            
            Console.Write("\n");

            
            int authorId = 1; 
            
            int total = bookAuthorRepo.GetTotalContributionByAuthor(authorId);
            
            var author = authorRepo.GetById(authorId);
            
            Console.Write($"7. Total contribution percentage for author {author.FirstName} {author.LastName}: {total}%\n\n");

            var mostActive = authorRepo.GetMostActiveAuthor();
            
            if (mostActive != null)
            {
                Console.Write($"8. Most active author: {mostActive.FirstName} {mostActive.LastName}, books: {mostActive.BookAuthors.Count}\n\n");
            }

            var bookWithMostCoAuthors = bookRepo.GetBookWithMostCoAuthors();
            
            if (bookWithMostCoAuthors != null)
            {
                int coAuthorCount = bookWithMostCoAuthors.BookAuthors.Count(ba => ba.Role == "CoAuthor");
                Console.Write($"9. Book with the most co-authors: {bookWithMostCoAuthors.Title}, co-authors: {coAuthorCount}\n\n");
            }

            Console.Write("10. Authors ordered by book count (descending):\n");
            
            var authorsOrdered = authorRepo.GetAuthorsOrderedByBookCount().ToList();
            
            foreach (var a in authorsOrdered)
            {
                Console.Write($"{a.FirstName} {a.LastName}: {a.BookCount} books\n");
            }
        }

       
    }



}