using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data.Repository.Entities;

namespace SchoolSystem.Data.Repository;

public partial class SchoolSystemDBContext : DbContext
{
    public SchoolSystemDBContext()
    {
    }

    public SchoolSystemDBContext(DbContextOptions<SchoolSystemDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Exam> Exams { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Fee> Fees { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAttendence> StudentAttendences { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherAttendence> TeacherAttendences { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=DESKTOP-G3BNQ24;Initial Catalog=SchoolSystemDB;TrustServerCertificate=true;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927C0754B8BC8");
        });

        modelBuilder.Entity<Exam>(entity =>
        {
            entity.HasKey(e => e.ExamId).HasName("PK__Exam__297521C7C6F0CCC4");

            entity.HasOne(d => d.Class).WithMany(p => p.Exams).HasConstraintName("FK__Exam__ClassId__5070F446");

            entity.HasOne(d => d.Subject).WithMany(p => p.Exams).HasConstraintName("FK__Exam__SubjectId__5165187F");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__Expense__1445CFD34172FBFA");

            entity.HasOne(d => d.Class).WithMany(p => p.Expenses).HasConstraintName("FK__Expense__ClassId__5441852A");

            entity.HasOne(d => d.Subject).WithMany(p => p.Expenses).HasConstraintName("FK__Expense__Subject__5535A963");
        });

        modelBuilder.Entity<Fee>(entity =>
        {
            entity.HasKey(e => e.FeesId).HasName("PK__Fees__7BD9FD27459AE123");

            entity.HasOne(d => d.Class).WithMany(p => p.Fees).HasConstraintName("FK__Fees__ClassId__4D94879B");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B99F0D2DD98");

            entity.HasOne(d => d.Class).WithMany(p => p.Students).HasConstraintName("FK__Student__ClassId__3C69FB99");
        });

        modelBuilder.Entity<StudentAttendence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StudentA__3214EC0755566926");

            entity.HasOne(d => d.Class).WithMany(p => p.StudentAttendences).HasConstraintName("FK__StudentAt__Class__49C3F6B7");

            entity.HasOne(d => d.Subject).WithMany(p => p.StudentAttendences).HasConstraintName("FK__StudentAt__Subje__4AB81AF0");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA3A825FA80EB");

            entity.HasOne(d => d.Class).WithMany(p => p.Subjects).HasConstraintName("FK__Subject__ClassId__398D8EEE");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teacher__EDF25964377426C4");

            entity.HasOne(d => d.Class).WithMany(p => p.Teachers).HasConstraintName("FK__Teacher__ClassId__3F466844");
        });

        modelBuilder.Entity<TeacherAttendence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherA__3214EC073B4A6EF6");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherAttendences).HasConstraintName("FK__TeacherAt__Teach__46E78A0C");
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherS__3214EC074984599E");

            entity.HasOne(d => d.Class).WithMany(p => p.TeacherSubjects).HasConstraintName("FK__TeacherSu__Class__4222D4EF");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherSubjects).HasConstraintName("FK__TeacherSu__Subje__4316F928");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSubjects).HasConstraintName("FK__TeacherSu__Teach__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
