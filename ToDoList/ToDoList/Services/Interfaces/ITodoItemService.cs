using ToDoList.Data.Entities;
using ToDoList.Data.Models;

namespace ToDoList.Services.Interfaces
{
    public interface ITodoItemService
    {
        Data.Entities.TodoItem GetTodoItemById(int id);
        IEnumerable<Data.Entities.TodoItem> GetAllTodoItems();
        Data.Entities.TodoItem PostTodoItem(TodoItemPostDto todoItemPostDto);
    }
}
