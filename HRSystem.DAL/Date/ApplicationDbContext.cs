using HRSystem.DAL.Models; 
using Microsoft.EntityFrameworkCore;

namespace HRSystem.DAL.Date  
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             
            modelBuilder.Entity<Department>()
                .ToTable("Departments")
                .HasKey(d => d.DepartmentId);

            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentName)
                .IsRequired()
                .HasMaxLength(100);

            
            modelBuilder.Entity<Employee>()
                .ToTable("Employees")
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

             
            modelBuilder.Entity<EmployeeDepartment>()
                .ToTable("EmployeeDepartments")
                .HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(ed => ed.Employee)
                .WithMany(e => e.EmployeeDepartments)
                .HasForeignKey(ed => ed.EmployeeId);

            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(ed => ed.Department)
                .WithMany(d => d.EmployeeDepartments)
                .HasForeignKey(ed => ed.DepartmentId);
        }
    }
}
