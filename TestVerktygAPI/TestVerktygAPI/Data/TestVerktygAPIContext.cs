using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestVerktygAPI.Models;

namespace TestVerktygAPI.Data
{
    public class TestVerktygAPIContext : DbContext
    {
        public TestVerktygAPIContext (DbContextOptions<TestVerktygAPIContext> options)
            : base(options)
        {
        }

        public DbSet<TestVerktygAPI.Models.User> User { get; set; }

        public DbSet<TestVerktygAPI.Models.Teacher> Teacher { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentExam>()
                .HasKey(t => new { t.StudentID, t.ExamID });

            modelBuilder.Entity<StudentExam>()
                .HasOne(op => op.Student)
                .WithMany(o => o.StudentExam)
                .HasForeignKey(op => op.StudentID);

            modelBuilder.Entity<StudentExam>()
                .HasOne(op => op.Exam)
                .WithMany(o => o.StudentExam)
                .HasForeignKey(op => op.ExamID);
        }

        public DbSet<TestVerktygAPI.Models.Question> Question { get; set; }

        public DbSet<TestVerktygAPI.Models.Student> Student { get; set; }

        public DbSet<TestVerktygAPI.Models.Answer> Answer { get; set; }

        public DbSet<TestVerktygAPI.Models.Exam> Exam { get; set; }

        public DbSet<TestVerktygAPI.Models.StudentExam> StudentExam { get; set; }
    }
}
