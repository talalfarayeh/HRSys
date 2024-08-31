using HR_Sysytem.Models;
using Microsoft.EntityFrameworkCore;

namespace HR_Sysytem.Date
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

            // Configure composite primary key for EmployeeDepartment
            modelBuilder.Entity<EmployeeDepartment>()
                .HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });

            // Additional configurations if needed
        }
    }
}
