using Posts;

namespace Users;

class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Post> Posts { get; set; } = new();

    public User()
    {
        
    }

    public User(string name)
    {
        Name = name;
    }

}
