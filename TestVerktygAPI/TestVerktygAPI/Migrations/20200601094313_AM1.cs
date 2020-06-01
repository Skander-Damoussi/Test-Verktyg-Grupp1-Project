using Microsoft.EntityFrameworkCore.Migrations;

namespace TestVerktygAPI.Migrations
{
    public partial class AM1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Results",
                table: "StudentExam",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Results",
                table: "StudentExam");
        }
    }
}
