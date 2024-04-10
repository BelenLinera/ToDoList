using ToDoList.Data.Entities;
using ToDoList.Data.Models;

namespace ToDoList.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByIdAlt(int id, bool includeTodos);
        IEnumerable<User> GetAllUsers(bool includeTodos);
        User PostUser(UserPostDto userPost);
    }
}
