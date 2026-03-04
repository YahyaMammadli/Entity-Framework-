using Users;
using Posts;

namespace UserInterface; //Я не мог сделать нормальный namespace потому что у меня постоянно конфликт был названий namespace и interface

interface IUserRepository
{
    IEnumerable<User> GetUsersWithPosts();
    User GetUserWithPostsById(int id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUserById(int id);
    IEnumerable<Post> GetUserPosts(int id);

}
