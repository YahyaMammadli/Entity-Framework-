using Users;

namespace Posts;

class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int UserId { get; set; }
    public User User { get; set; }


    public Post()
    {
        
    }

    public Post(string title, int userId)
    {
        Title = title;
        UserId = userId;
    }

    

}
