using Core.UserRepository;
using Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using PostInterface;
using Posts;
using Program.Core;
using UserInterface;
using Users;

namespace Programж
{
    class Program
    {

        static void Run(AppDbContext context)
        {
            var userRepo = new UserRepository(context);
            var postRepo = new PostRepository(context);

            while (true)
            {
                Console.Write("\n===== Menu =====\n\n");
                Console.Write("1. Add User\n");
                Console.Write("2. Update User\n");
                Console.Write("3. Delete User\n");
                Console.Write("4. Add Post\n");
                Console.Write("5. Update Post\n");
                Console.Write("6. Delete Post\n");
                Console.Write("7. Show all users with posts\n");
                Console.Write("0. Exit\n");
                Console.Write("Choose an option => ");

                string choice = Console.ReadLine()?.Trim() ?? "";

                switch (choice)
                {
                    case "1":
                        AddUser(userRepo);
                        break;
                    case "2":
                        UpdateUser(userRepo);
                        break;
                    case "3":
                        DeleteUser(userRepo);
                        break;
                    case "4":
                        AddPost(userRepo, postRepo);
                        break;
                    case "5":
                        UpdatePost(postRepo);
                        break;
                    case "6":
                        DeletePost(postRepo);
                        break;
                    case "7":
                        ShowAllUsersWithPosts(userRepo);
                        break;
                    case "0":
                        Console.Write("Goodbye!\n\n");
                        return;
                    default:
                        Console.Write("Invalid option! Please try again.");
                        break;
                }
            }
        }




        #region Validation

        static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? "";

                if (!string.IsNullOrWhiteSpace(input))
                    return input;

                Console.Write("Input cannot be empty! Please try again.\n");
                Console.Clear();
            }
        }
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? "";
                if (int.TryParse(input, out int result))
                    return result;
                
                Console.Write("Invalid number. Please enter a valid integer!\n");
                Console.Clear();
            }
        }
        #endregion








        static void AddUser(IUserRepository userRepo)
        {
            Console.Write("\n--- All Users with Posts ---\n\n");
            string name = ReadString("Enter user name => ");
            var user = new User(name);
            userRepo.AddUser(user);
            Console.Write($"User '{name}' added successfully with ID {user.Id}!\n");
        }





        static void UpdateUser(IUserRepository userRepo)
        {
            Console.Write("\n--- Update User ---\n\n");
            int id = ReadInt("Enter user ID to update => ");
            var existing = userRepo.GetUserWithPostsById(id);
            if (existing == null)
            {
                Console.Write($"User with ID {id} not found!\n");
                return;
            }

            Console.Write($"Current name: {existing.Name}\n\n");
            string newName = ReadString("Enter new name => ");
            var updatedUser = new User(newName) { Id = id };
            userRepo.UpdateUser(updatedUser);
            Console.Write("User updated successfully!\b");
        }




        static void DeleteUser(IUserRepository userRepo)
        {
            Console.Write("\n--- Delete User ---\n\n");
            int id = ReadInt("Enter user ID to delete => ");
            var existing = userRepo.GetUserWithPostsById(id);
            if (existing == null)
            {
                Console.Write($"User with ID {id} not found!\n");
                return;
            }

            userRepo.DeleteUserById(id);
            Console.Write("User deleted successfully!\n");
        }





        static void AddPost(IUserRepository userRepo, IPostRepository postRepo)
        {
            Console.Write("\n--- Add Post ---\n\n");
            string title = ReadString("Enter post title => ");
            int userId = ReadInt("Enter user ID => ");

            
            var user = userRepo.GetUserWithPostsById(userId);
            if (user == null)
            {
                Console.Write($"User with ID {userId} not found@ Cannot add post!\n");
                return;
            }

            var post = new Post(title, userId);
            postRepo.AddPost(post);
            Console.Write($"Post '{title}' added successfully with ID {post.Id}!\n");
        }





        static void UpdatePost(IPostRepository postRepo)
        {
            Console.Write("\n--- Update Post ---\n\n");
            int id = ReadInt("Enter post ID to update => ");
            var existing = postRepo.GetPostById(id);
            if (existing == null)
            {
                Console.Write($"Post with ID {id} not found!\n");
                return;
            }

            Console.Write($"Current title: {existing.Title}\n");
            string newTitle = ReadString("Enter new title => ");
            var updatedPost = new Post { Id = id, Title = newTitle };
            postRepo.UpdatePost(updatedPost);
            Console.Write("Post updated successfully!\n");
        }




        static void DeletePost(IPostRepository postRepo)
        {
            Console.Write   ("\n--- Delete Post ---\n\n");
            int id = ReadInt("Enter post ID to delete => ");
            var existing = postRepo.GetPostById(id);
            if (existing == null)
            {
                Console.Write($"Post with ID {id} not found!\n");
                return;
            }

            postRepo.DeletePostById(id);
            Console.Write("Post deleted successfully!\n");
        }




        
        static void ShowAllUsersWithPosts(IUserRepository userRepo)
        {
            Console.Write("\n--- All Users with Posts ---\n\n");
            var users = userRepo.GetUsersWithPosts();
            if (!users.Any())
            {
                Console.Write("No users found!\n");
                return;
            }

            foreach (var user in users)
            {
                Console.Write($"User ID: {user.Id}, Name: {user.Name}\n");
                if (user.Posts.Any())
                {
                    foreach (var post in user.Posts)
                    {
                        Console.Write($"  Post ID: {post.Id}, Title: {post.Title}\n");
                    }
                }
                else
                {
                    Console.Write("  No posts!\n");
                }
            }
        }





        static void Main()
        {
            using var context = new AppDbContext();
            Run(context);
        }




    }
}
