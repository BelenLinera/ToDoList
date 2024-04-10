using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    public partial class addComents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Address", "Email", "Name" },
                values: new object[] { 1, "San juan 1129", "belen.linera@gmail.com", "belen" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Address", "Email", "Name" },
                values: new object[] { 2, "corrientes 1323", "florencia.colombo@gmail.com", "florencia" });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id_Todo_Item", "Description", "Id_User", "Title" },
                values: new object[] { 1, "descripcion 1", 1, "titulo 1" });

            migrationBuilder.InsertData(
                table: "TodoItems",
                columns: new[] { "Id_Todo_Item", "Description", "Id_User", "Title" },
                values: new object[] { 2, "descripcion 2", 2, "titulo 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id_Todo_Item",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TodoItems",
                keyColumn: "Id_Todo_Item",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id_User",
                keyValue: 2);
        }
    }
}
