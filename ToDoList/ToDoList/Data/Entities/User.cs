using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Data.Entities
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_User { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        //inicializarlo para que no entre en bucle
        public ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
    }
}
