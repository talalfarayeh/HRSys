using HR_System.BLL.Sarvices.Interfaces;
using HR_System.BLL.Sarvices;
using HRSystem.BLL.Interfaces;
using HRSystem.BLL.Services;
using HRSystem.DAL.Repositories.IRepositories;
using HRSystem.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
             services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ILeaveRequestService, LeaveRequestService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IGoalService, GoalService>();
            services.AddTransient<IPerformanceReviewService, PerformanceReviewService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<IPayrollService, PayrollService>();
            services.AddTransient<IPayrollPdfService, PayrollPdfService>();
            services.AddTransient<IBenefitService, BenefitService>();
            services.AddTransient<IEmployeeBenefitService, EmployeeBenefitService>();
            services.AddTransient<IComplianceReportService, ComplianceReportService>();
            services.AddTransient<ISalaryComponentService, SalaryComponentService>();

            return services;
        }
    }
}
