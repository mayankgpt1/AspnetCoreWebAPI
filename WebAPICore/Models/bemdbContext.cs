using Microsoft.EntityFrameworkCore;

namespace WebAPICore.Models
{
    public partial class BemdbContext : DbContext
    {
        public BemdbContext()
        {
        }

        public BemdbContext(DbContextOptions<BemdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Department2> Department2 { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=devdb; User ID=sa;Password=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "bem");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PkDepartment).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Department2>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PkDepartment).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
