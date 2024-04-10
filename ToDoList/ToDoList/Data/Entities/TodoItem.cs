using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Data.Entities
{
    public class TodoItem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Todo_Item { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [ForeignKey("Id_User")]
        public int Id_User { get; set; }
        public User User { get; set; }
    }
}
