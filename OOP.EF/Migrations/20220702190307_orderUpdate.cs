using Microsoft.EntityFrameworkCore.Migrations;

namespace OOP.EF.Migrations
{
    public partial class orderUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "delivererId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "Orders",
                newName: "sizeId");

            migrationBuilder.AlterColumn<int>(
                name: "pizzaId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sizeId",
                table: "Orders",
                newName: "size");

            migrationBuilder.AlterColumn<string>(
                name: "pizzaId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "delivererId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
