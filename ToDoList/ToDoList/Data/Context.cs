using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using ToDoList.Data.Entities;

namespace ToDoList.Data
{
    public class Context : DbContext

    {
        //propiedades
        public DbSet<User>? Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }

        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id_User = 1,
                    Name = "belen",
                    Email = "belen.linera@gmail.com",
                    Address = "San juan 1129"

                },
                new User
                {
                    Id_User = 2,
                    Name = "florencia",
                    Email = "florencia.colombo@gmail.com",
                    Address = "corrientes 1323"

                });
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    Id_Todo_Item = 1,
                    Title = "titulo 1",
                    Description = "descripcion 1",
                    Id_User = 1
                },
                new TodoItem
                {
                    Id_Todo_Item = 2,
                    Title = "titulo 2",
                    Description = "descripcion 2",
                    Id_User = 2

                });
            modelBuilder.Entity<TodoItem>()
                //configuracion de uno a muchos entre User y TodoItem
                .HasOne(t => t.User) //un todoitem tiene un usuario
                .WithMany(u => u.TodoItems) //un usuario puede tener muchas todoitem
                .HasForeignKey(t => t.Id_User); //la foreign key en TodoItem es Id_User
        }
    }
}
