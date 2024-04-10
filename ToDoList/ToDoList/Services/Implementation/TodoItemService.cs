using ToDoList.Data;
using ToDoList.Data.Entities;
using ToDoList.Data.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services.Implementation
{
    public class TodoItemService : ITodoItemService

    {
        private readonly Context _context;
        public TodoItemService(Context context)
        {
            _context = context;
        }
        public Data.Entities.TodoItem GetTodoItemById(int id)
        {
            try
            {
                return _context.TodoItems.FirstOrDefault(t => t.Id_Todo_Item == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el usuario con Id {id}: {ex.Message}", ex);
            }
        }

        public IEnumerable<Data.Entities.TodoItem> GetAllTodoItems()
        {
            try
            {
                return _context.TodoItems.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los elementos de TodoItem: {ex.Message}", ex);
            }
        }


        public Data.Entities.TodoItem PostTodoItem(TodoItemPostDto todoItemPostDto)
        {
            try
            {
                var newTodoItem = new Data.Entities.TodoItem
                {
                   
                    Title = todoItemPostDto.Title,
                    Description = todoItemPostDto.Description,
                    Id_User = todoItemPostDto.Id_User
                };
                _context.TodoItems.Add(newTodoItem);
                _context.SaveChanges();
                return newTodoItem;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al guardar el nuevo elemento de TodoItem: {ex.Message}", ex);
            }
            
        }
    }

}

