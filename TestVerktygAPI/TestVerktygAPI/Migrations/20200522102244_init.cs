using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestVerktygAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsTeacher = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Exam",
                columns: table => new
                {
                    ExamID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(nullable: true),
                    ExamName = table.Column<string>(nullable: true),
                    ExamDate = table.Column<DateTime>(nullable: false),
                    Results = table.Column<int>(nullable: false),
                    StudentUserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exam", x => x.ExamID);
                    table.ForeignKey(
                        name: "FK_Exam_User_StudentUserID",
                        column: x => x.StudentUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfPoints = table.Column<int>(nullable: false),
                    QuestionTitle = table.Column<string>(nullable: true),
                    ExamID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionID);
                    table.ForeignKey(
                        name: "FK_Question_Exam_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exam",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExam",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false),
                    ExamID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExam", x => new { x.StudentID, x.ExamID });
                    table.ForeignKey(
                        name: "FK_StudentExam_Exam_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exam",
                        principalColumn: "ExamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentExam_User_StudentID",
                        column: x => x.StudentID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternative",
                columns: table => new
                {
                    AlternativeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(nullable: true),
                    QuestionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternative", x => x.AlternativeID);
                    table.ForeignKey(
                        name: "FK_Alternative_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    AnswerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrectAnswer = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.AnswerID);
                    table.ForeignKey(
                        name: "FK_Answer_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "Question",
                        principalColumn: "QuestionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternative_QuestionID",
                table: "Alternative",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionID",
                table: "Answer",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Exam_StudentUserID",
                table: "Exam",
                column: "StudentUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExamID",
                table: "Question",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ExamID",
                table: "StudentExam",
                column: "ExamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alternative");

            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "StudentExam");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Exam");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
