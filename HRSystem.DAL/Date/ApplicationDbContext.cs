﻿
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // تعريف المفتاح الأساسي للـ PerformanceReview
            modelBuilder.Entity<PerformanceReview>()
                .HasKey(pr => pr.PerformanceReviewId);

            // تعريف العلاقة مع EmployeeId (Cascade Delete مفعل)
            modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Employee)
                .WithMany(e => e.PerformanceReviews)  // هنا تم إصلاح الخطأ بعد إضافة PerformanceReviews في Employee
                .HasForeignKey(pr => pr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade Delete

            // تعريف العلاقة مع ReviewerId (بدون Cascade Delete لتجنب المشكلة)
            modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Reviewer)
                .WithMany()
                .HasForeignKey(pr => pr.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict); // No Action (بدون الحذف المتتابع)

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
            // إضافة العلاقة بين الموظف ومديره
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)  // علاقة بين الموظف ومديره
                .WithMany(m => m.Subordinates)  // علاقة المدير بموظفيه
                .HasForeignKey(e => e.ManagerId)  // المفتاح الأجنبي هو ManagerId
                .OnDelete(DeleteBehavior.Restrict);  // منع الحذف المتسلسل

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

            // العلاقة بين EmployeeRole و Employee
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(er => er.Employee)
                .WithMany(e => e.EmployeeRoles)
                .HasForeignKey(er => er.EmployeeId);

            // العلاقة بين EmployeeRole و Role
            modelBuilder.Entity<EmployeeRole>()
                .HasOne(er => er.Role)
                .WithMany(r => r.EmployeeRoles)
                .HasForeignKey(er => er.RoleId);

            // Payroll Table
            modelBuilder.Entity<Payroll>()
                .HasKey(p => p.PayrollId);

            modelBuilder.Entity<Payroll>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId);

            // SalaryComponents Table
            modelBuilder.Entity<SalaryComponent>()
                .HasKey(sc => sc.SalaryComponentId);

            modelBuilder.Entity<SalaryComponent>()
                .HasOne(sc => sc.Employee)
                .WithMany(e => e.SalaryComponents)
                .HasForeignKey(sc => sc.EmployeeId);
            // Payroll entity configuration
            modelBuilder.Entity<Payroll>()
                .Property(p => p.BasicSalary)
                .HasColumnType("decimal(18,2)"); // تحديد النوع والدقة للـ decimal

            modelBuilder.Entity<Payroll>()
                .Property(p => p.Bonus)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payroll>()
                .Property(p => p.Deductions)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payroll>()
                .Property(p => p.NetSalary)
                .HasColumnType("decimal(18,2)");

            // SalaryComponent entity configuration
            modelBuilder.Entity<SalaryComponent>()
                .Property(sc => sc.Amount)
                .HasColumnType("decimal(18,2)"); // تحديد النوع والدقة للـ decimal

            modelBuilder.Entity<EmployeeBenefit>()
       .Property(e => e.CostToCompany)
       .HasColumnType("decimal(18,2)");
        }
    }
}
 