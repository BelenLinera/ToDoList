using ToDoList.Data.Entities;

namespace ToDoList.Data.Models
{
    public class UserIncludeTodosDto
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public ICollection<Entities.TodoItem> TodoItems { get; set; }
    }
}
