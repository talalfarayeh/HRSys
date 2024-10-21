using HR_System.BLL.DTOs.HR_System.BLL.DTOs;
using HR_System.BLL.DTOs.Payroll;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories;
using HRSystem.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
    public class PayrollService : IPayrollService
    {
        private readonly IPayrollRepository _payrollRepository;
        private readonly ISalaryComponentRepository _salaryComponentRepository;
        private readonly IEmployeeBenefitRepository _employeeBenefitRepository;
        public PayrollService(IPayrollRepository payrollRepository, ISalaryComponentRepository salaryComponentRepository, IEmployeeBenefitRepository employeeBenefitRepository)
        {
            _payrollRepository = payrollRepository;
            _salaryComponentRepository = salaryComponentRepository;
            _employeeBenefitRepository = employeeBenefitRepository;
        }


        public async Task<PayrollDTO> GeneratePayrollAsync(int employeeId, int workingDays)
        {
            var salaryComponents = await _salaryComponentRepository.GetSalaryComponentsByEmployeeIdAsync(employeeId);
            if (salaryComponents == null || !salaryComponents.Any())
            {
                throw new Exception("Salary components not found for the employee.");
            }
            var basicSalary = salaryComponents.FirstOrDefault(sc => sc.ComponentName == "Basic Salary")?.Amount ?? 0;
            var bonus = salaryComponents.FirstOrDefault(sc => sc.ComponentName == "Bonus")?.Amount ?? 0;
            var deductions = salaryComponents.FirstOrDefault(sc => sc.ComponentName == "Deductions")?.Amount ?? 0;

            // الحصول على المزايا المرتبطة بالموظف
            var employeeBenefits = await _employeeBenefitRepository.GetBenefitsByEmployeeIdAsync(employeeId);
            var totalBenefitsCost = employeeBenefits.Sum(eb => eb.CostToCompany);

            var netSalary = ((basicSalary / 30) * workingDays) + bonus - deductions - totalBenefitsCost;

            var payroll = new Payroll
            {
                EmployeeId = employeeId,
                BasicSalary = basicSalary,
                Bonus = bonus,
                Deductions = deductions + totalBenefitsCost,
                NetSalary = netSalary,
                PaymentDate = DateTime.Now,
                PaymentStatus = "Pending"
            };
            await _payrollRepository.AddPayrollAsync(payroll);
            return new PayrollDTO
            {
                EmployeeId = payroll.EmployeeId,

                BasicSalary = payroll.BasicSalary,
                Bonus = payroll.Bonus,
                Deductions = payroll.Deductions,
                NetSalary = payroll.NetSalary,
                PaymentDate = payroll.PaymentDate,
                PaymentStatus = payroll.PaymentStatus
            };


        }

       

       

        public async Task<List<PayrollDTO>> GetPayrollHistoryAsync(int employeeId)
        {
            var payrolls = await _payrollRepository.GetPayrollHistoryByEmployeeIdAsync(employeeId);
            return payrolls.Select(p => new PayrollDTO
            {
                EmployeeId = p.EmployeeId,
                BasicSalary = p.BasicSalary,
                Bonus = p.Bonus,
                Deductions = p.Deductions,
                NetSalary = p.NetSalary,
                PaymentDate = p.PaymentDate,
                PaymentStatus = p.PaymentStatus
            }).ToList();
        }

        public async Task ApprovePayrollAsync(int payrollId)
        {
            await _payrollRepository.ApprovePayrollAsync(payrollId);
        }

        public async Task<PayrollDTO> GetPayrollByIdAsync(int payrollId)
        {
            var payroll = await _payrollRepository.GetPayrollByIdAsync(payrollId);

            if (payroll == null) return null;

            var employee = payroll.Employee;

            return new PayrollDTO
            {
                PayrollId = payroll.PayrollId,
                EmployeeId = payroll.EmployeeId,
                EmployeeFirstName = employee.FirstName,
                EmployeeLastName = employee.LastName,
                BasicSalary = payroll.BasicSalary,
                Bonus = payroll.Bonus,
                Deductions = payroll.Deductions,
                NetSalary = payroll.NetSalary,
                PaymentDate = payroll.PaymentDate,
                PaymentStatus = payroll.PaymentStatus
            };
        }
    }
}
