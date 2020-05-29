using Microsoft.EntityFrameworkCore.Migrations;

namespace TestVerktygAPI.Migrations
{
    public partial class AM6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCorrectAnswer",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswer",
                table: "Question",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectAnswer",
                table: "Question");

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrectAnswer",
                table: "Question",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
