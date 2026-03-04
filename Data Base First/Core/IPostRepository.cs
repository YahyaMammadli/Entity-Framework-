using Posts;
using Users;


namespace PostInterface;

interface IPostRepository
{
    void AddPost(Post post);
    void UpdatePost(Post post);
    void DeletePostById(int id);
    IEnumerable<Post> GetPostByUserId(int userId);
    Post GetPostById(int id);

}
