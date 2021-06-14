using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JwtAssignment1.Models
{
    public partial class StudentDetailsContext : DbContext
    {
        public StudentDetailsContext()
        {
        }

        public StudentDetailsContext(DbContextOptions<StudentDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GenderMaster> GenderMaster { get; set; }
        public virtual DbSet<StudentInfo> StudentInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-HNRKCQK\\SQLEXPRESS;Database=StudentDetails;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenderMaster>(entity =>
            {
                entity.ToTable("genderMaster");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GenderName)
                    .IsRequired()
                    .HasColumnName("genderName")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<StudentInfo>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("studentInfo");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Skills)
                    .IsRequired()
                    .HasMaxLength(180);

                entity.HasOne(d => d.GenderNavigation)
                    .WithMany(p => p.StudentInfo)
                    .HasForeignKey(d => d.Gender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_studentInfo_genderMaster");
            });
        }
    }
}
