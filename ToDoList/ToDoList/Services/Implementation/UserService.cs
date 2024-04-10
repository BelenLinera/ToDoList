using ToDoList.Data.Entities;
using ToDoList.Data;
using ToDoList.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Models;

namespace ToDoList.Services.Implementation
{
        public class UserService : IUserService

        {
            private readonly Context _context;
            public UserService(Context context)
            {
                _context = context;
            }
            public User GetUserByIdAlt(int id, bool includeTodos)
            {
                try
                {
                if (includeTodos)
                {
                    var result = _context.Users.Include(t => t.TodoItems)
                        .Where(u => u.Id_User == id).FirstOrDefault();
                }
                    return _context.Users.FirstOrDefault(u => u.Id_User == id);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener el usuario con Id {id}: {ex.Message}", ex);
                }
            }

        public IEnumerable<User> GetAllUsers(bool includeTodos)
        {
            try
            {
                if (includeTodos)
                {
                    return _context.Users.Include(u => u.TodoItems).ToList();
                }
                else
                {
                    return _context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los usuarios: {ex.Message}", ex);
            }
        }

        public User PostUser(UserPostDto userPostDto)
             {
                var newUser = new User
                {
                    Name = userPostDto.Name,
                    Email = userPostDto.Email,
                    Address = userPostDto.Address
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();
                return newUser;
             }
   
        }
    
}
