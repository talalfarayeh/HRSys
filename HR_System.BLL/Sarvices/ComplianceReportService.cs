using HR_System.BLL.DTOs.Payroll;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
    public class ComplianceReportService : IComplianceReportService
    {
        private readonly IPayrollRepository _payrollRepository;

        public ComplianceReportService(IPayrollRepository payrollRepository)
        {
            _payrollRepository = payrollRepository;
        }

        public async Task<List<PayrollReportDTO>> GenerateYearEndTaxReportAsync(int year)
        {
            var payrolls = await _payrollRepository.GetPayrollsForYearAsync(year);

            return payrolls.Select(p => new PayrollReportDTO
            {
                EmployeeId = p.EmployeeId,
                EmployeeName = $"{p.Employee.FirstName} {p.Employee.LastName}",
                BasicSalary = p.BasicSalary,
                Bonus = p.Bonus,
                Deductions = p.Deductions,
                NetSalary = p.NetSalary,
                TaxesPaid = p.BasicSalary - p.NetSalary
            }).ToList();
        }
    }
}
