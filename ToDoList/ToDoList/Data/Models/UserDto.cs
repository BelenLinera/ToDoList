namespace ToDoList.Data.Models
{
    public class UserDto
    {
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<TodoItemDto> TodoItems { get; set; }
    }
}
