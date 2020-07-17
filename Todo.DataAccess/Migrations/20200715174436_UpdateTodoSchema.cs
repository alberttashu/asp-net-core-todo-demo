using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Api.Migrations
{
    public partial class UpdateTodoSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_TodoLists_TodoListId",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists");

            migrationBuilder.EnsureSchema(
                name: "Planning");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "Todo",
                newSchema: "Planning");

            migrationBuilder.RenameTable(
                name: "TodoLists",
                newName: "TodoList",
                newSchema: "Planning");

            migrationBuilder.RenameIndex(
                name: "IX_Todos_TodoListId",
                schema: "Planning",
                table: "Todo",
                newName: "IX_Todo_TodoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                schema: "Planning",
                table: "Todo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoList",
                schema: "Planning",
                table: "TodoList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todo_TodoList_TodoListId",
                schema: "Planning",
                table: "Todo",
                column: "TodoListId",
                principalSchema: "Planning",
                principalTable: "TodoList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todo_TodoList_TodoListId",
                schema: "Planning",
                table: "Todo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoList",
                schema: "Planning",
                table: "TodoList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                schema: "Planning",
                table: "Todo");

            migrationBuilder.RenameTable(
                name: "TodoList",
                schema: "Planning",
                newName: "TodoLists");

            migrationBuilder.RenameTable(
                name: "Todo",
                schema: "Planning",
                newName: "Todos");

            migrationBuilder.RenameIndex(
                name: "IX_Todo_TodoListId",
                table: "Todos",
                newName: "IX_Todos_TodoListId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_TodoLists_TodoListId",
                table: "Todos",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
