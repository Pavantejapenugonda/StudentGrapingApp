using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CPSC440_F2023_Project.Model;

public partial class StudentContext : DbContext
{
    public StudentContext()
    {
    }

    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseHistory> CourseHistories { get; set; }

    public virtual DbSet<Info> Infos { get; set; }

    public virtual DbSet<Professor> Professors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-76U6FC6;Integrated Security=true;TrustServerCertificate=True;Initial Catalog=Student;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.ToTable("Course");

            entity.Property(e => e.CourseId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ProfessorId)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Professor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_Professor");
        });

        modelBuilder.Entity<CourseHistory>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.CourseId });

            entity.ToTable("CourseHistory");

            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.CourseId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ProfessorId)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Course).WithMany(p => p.CourseHistories)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseHistory_Course");

            entity.HasOne(d => d.Professor).WithMany(p => p.CourseHistories)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseHistory_Professor");

            entity.HasOne(d => d.Student).WithMany(p => p.CourseHistories)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseHistory_Info");
        });

        modelBuilder.Entity<Info>(entity =>
        {
            entity.HasKey(e => e.StudentId);

            entity.ToTable("Info");

            entity.Property(e => e.StudentId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Professor>(entity =>
        {
            entity.ToTable("Professor");

            entity.Property(e => e.ProfessorId)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
