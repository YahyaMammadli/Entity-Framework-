using Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using PostInterface;
using Posts;
using Users;

namespace Program.Core 
{
    class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;


        public PostRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPost(Post post)
        {
            
        
            _context.Posts.Add(post);
            _context.SaveChanges();
        
        }

        public void DeletePostById(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Post> GetPostByUserId(int userId)
        {
            return _context.Posts
                   .Where(post => post.UserId == userId)
                   .ToList();
        }

        public void UpdatePost(Post post)
        {


            var existing = _context.Posts.Find(post.Id);
            if (existing is not null)
            {
                // Тут я решил что нельзя менять UserId и поэтому и не меняю его
                existing.Title = post.Title;
                

                _context.SaveChanges();

            }
        }


        public Post GetPostById(int id)
        {
            return _context.Posts.Find(id);
        }




    }
}
