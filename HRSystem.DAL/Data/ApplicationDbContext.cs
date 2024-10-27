
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
        public DbSet<Role> Roles { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<SalaryComponent> SalaryComponents { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<EmployeeBenefit> EmployeeBenefits { get; set; }
        public DbSet<TaxRule> TaxRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<PerformanceReview>()
                .HasKey(pr => pr.PerformanceReviewId);

             modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Employee)
                .WithMany(e => e.PerformanceReviews)  
                .HasForeignKey(pr => pr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);  

           
            modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Reviewer)
                .WithMany()
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict); 

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
            
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)  
                .WithMany(m => m.Subordinates)  
                .HasForeignKey(e => e.ManagerId)  
                .OnDelete(DeleteBehavior.Restrict);  

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

            modelBuilder.Entity<Role>()
                 .ToTable("Roles")
                .HasKey(r => r.RoleId);

            modelBuilder.Entity<Role>()
                .Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<EmployeeRole>().ToTable("EmployeeRoles")
      .HasKey(er => new { er.EmployeeId, er.RoleId });

            
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(er => er.Employee)
                .WithMany(e => e.EmployeeRoles)
                .HasForeignKey(er => er.EmployeeId);
 
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(er => er.Role)
                .WithMany(r => r.EmployeeRoles)
                .HasForeignKey(er => er.RoleId);

            
            modelBuilder.Entity<Payroll>()
                .HasKey(p => p.PayrollId);

            modelBuilder.Entity<Payroll>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId);

            
            modelBuilder.Entity<SalaryComponent>()
                .HasKey(sc => sc.SalaryComponentId);

            modelBuilder.Entity<SalaryComponent>()
                .HasOne(sc => sc.Employee)
                .WithMany(e => e.SalaryComponents)
                .HasForeignKey(sc => sc.EmployeeId);
            
            modelBuilder.Entity<Payroll>()
                .Property(p => p.BasicSalary)
                .HasColumnType("decimal(18,2)");  

            modelBuilder.Entity<Payroll>()
                .Property(p => p.Bonus)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payroll>()
                .Property(p => p.Deductions)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payroll>()
                .Property(p => p.NetSalary)
                .HasColumnType("decimal(18,2)");

           
            modelBuilder.Entity<SalaryComponent>()
                .Property(sc => sc.Amount)
                .HasColumnType("decimal(18,2)");  
            modelBuilder.Entity<EmployeeBenefit>()
       .Property(e => e.CostToCompany)
       .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<TaxRule>()
                .Property(tr => tr.MinSalary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TaxRule>()
                .Property(tr => tr.MaxSalary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<TaxRule>()
                .Property(tr => tr.TaxPercentage)
                .HasColumnType("decimal(5,2)");
        }
    }
}
 