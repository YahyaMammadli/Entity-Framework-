using Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using Posts;
using System;
using UserInterface;
using Users;

namespace Core.UserRepository;

class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {

        _context.Users.Add(user);
        _context.SaveChanges();


    }

    public void DeleteUserById(int id)
    {

        var user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }


    }

    public IEnumerable<Post> GetUserPosts(int id)
    {

        return _context.Posts.Where(x => x.UserId == id)
                   .ToList();


    }

    public IEnumerable<User> GetUsersWithPosts()
    {
        return _context.Users
                   .Include(u => u.Posts)
                   .ToList();



    }

    public User GetUserWithPostsById(int id)
    {
        return _context.Users
                   .Include(u => u.Posts)
                   .FirstOrDefault(u => u.Id == id);
    }

    public void UpdateUser(User user)
    {
        var existing = _context.Users.Find(user.Id);
        if (existing is not null)
        {
            existing.Name = user.Name;

            _context.SaveChanges();
        
        }

    }

    
}
