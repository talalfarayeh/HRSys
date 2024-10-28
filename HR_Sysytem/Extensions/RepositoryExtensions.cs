using Microsoft.Extensions.DependencyInjection;
using HRSystem.DAL.Repositories;
using HRSystem.DAL.Repositories.IRepositories;

namespace HRSystem.API.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();
            services.AddScoped<IPerformanceReviewRepository, PerformanceReviewRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IPayrollRepository, PayrollRepository>();
            services.AddScoped<ISalaryComponentRepository, SalaryComponentRepository>();
            services.AddScoped<IBenefitRepository, BenefitRepository>();
            services.AddScoped<IEmployeeBenefitRepository, EmployeeBenefitRepository>();
            services.AddScoped<ITaxRuleRepository, TaxRuleRepository>();
            return services;
        }
    }
}
