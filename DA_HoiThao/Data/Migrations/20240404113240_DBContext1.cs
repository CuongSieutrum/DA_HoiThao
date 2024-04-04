using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA_HoiThao.Data.Migrations
{
    public partial class DBContext1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SDT",
                table: "Students",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Students",
                newName: "SDT");
        }
    }
}
