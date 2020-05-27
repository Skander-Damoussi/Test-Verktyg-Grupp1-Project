using Microsoft.EntityFrameworkCore.Migrations;

namespace TestVerktygAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Exam_Student_StudentID",
                table: "Exam");

            migrationBuilder.DropIndex(
                name: "IX_Exam_StudentID",
                table: "Exam");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "Exam");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "Exam",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QuestionID",
                table: "Answer",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exam_StudentID",
                table: "Exam",
                column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Question_QuestionID",
                table: "Answer",
                column: "QuestionID",
                principalTable: "Question",
                principalColumn: "QuestionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exam_Student_StudentID",
                table: "Exam",
                column: "StudentID",
                principalTable: "Student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
