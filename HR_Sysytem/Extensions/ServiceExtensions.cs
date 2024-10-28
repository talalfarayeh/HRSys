using Microsoft.Extensions.DependencyInjection;
using HR_System.BLL.Sarvices.Interfaces;
using HR_System.BLL.Sarvices;
using HRSystem.BLL.Interfaces;
using HRSystem.BLL.Services;

namespace HRSystem.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ILeaveRequestService, LeaveRequestService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IGoalService, GoalService>();
            services.AddScoped<IPerformanceReviewService, PerformanceReviewService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IPayrollService, PayrollService>();
            services.AddScoped<IPayrollPdfService, PayrollPdfService>();
            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<IEmployeeBenefitService, EmployeeBenefitService>();
            services.AddScoped<IComplianceReportService, ComplianceReportService>();
            services.AddScoped<ISalaryComponentService, SalaryComponentService>();
            return services;
        }
    }
}
