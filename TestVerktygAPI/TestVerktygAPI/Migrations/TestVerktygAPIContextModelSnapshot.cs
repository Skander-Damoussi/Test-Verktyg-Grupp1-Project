﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestVerktygAPI.Data;

namespace TestVerktygAPI.Migrations
{
    [DbContext(typeof(TestVerktygAPIContext))]
    partial class TestVerktygAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestVerktygAPI.Models.Alternative", b =>
                {
                    b.Property<int>("AlternativeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("AlternativeID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Alternative");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Answer", b =>
                {
                    b.Property<int>("AnswerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionID")
                        .HasColumnType("int");

                    b.HasKey("AnswerID");

                    b.HasIndex("QuestionID");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Exam", b =>
                {
                    b.Property<int>("ExamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Results")
                        .HasColumnType("int");

                    b.Property<int?>("StudentUserID")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExamID");

                    b.HasIndex("StudentUserID");

                    b.ToTable("Exam");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Question", b =>
                {
                    b.Property<int>("QuestionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExamID")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPoints")
                        .HasColumnType("int");

                    b.Property<string>("QuestionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestionID");

                    b.HasIndex("ExamID");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.StudentExam", b =>
                {
                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.Property<int>("ExamID")
                        .HasColumnType("int");

                    b.HasKey("StudentID", "ExamID");

                    b.HasIndex("ExamID");

                    b.ToTable("StudentExam");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsTeacher")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Student", b =>
                {
                    b.HasBaseType("TestVerktygAPI.Models.User");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Teacher", b =>
                {
                    b.HasBaseType("TestVerktygAPI.Models.User");

                    b.Property<int>("TeacherID")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Alternative", b =>
                {
                    b.HasOne("TestVerktygAPI.Models.Question", null)
                        .WithMany("Alternatives")
                        .HasForeignKey("QuestionID");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Answer", b =>
                {
                    b.HasOne("TestVerktygAPI.Models.Question", null)
                        .WithMany("CorrectAnswer")
                        .HasForeignKey("QuestionID");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Exam", b =>
                {
                    b.HasOne("TestVerktygAPI.Models.Student", null)
                        .WithMany("ListExam")
                        .HasForeignKey("StudentUserID");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.Question", b =>
                {
                    b.HasOne("TestVerktygAPI.Models.Exam", null)
                        .WithMany("Questions")
                        .HasForeignKey("ExamID");
                });

            modelBuilder.Entity("TestVerktygAPI.Models.StudentExam", b =>
                {
                    b.HasOne("TestVerktygAPI.Models.Exam", "Exam")
                        .WithMany("StudentExam")
                        .HasForeignKey("ExamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestVerktygAPI.Models.Student", "Student")
                        .WithMany("StudentExam")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
