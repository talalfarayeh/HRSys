using HR_System.BLL.DTOs.Benefit;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
    public class EmployeeBenefitService : IEmployeeBenefitService
    {
        private readonly IEmployeeBenefitRepository _employeeBenefitRepository;

        public EmployeeBenefitService(IEmployeeBenefitRepository employeeBenefitRepository)
        {
            _employeeBenefitRepository = employeeBenefitRepository;
        }

        public async Task EnrollEmployeeInBenefitAsync(int employeeId, int benefitId, decimal costToCompany)
        {
            var employeeBenefit = new EmployeeBenefit
            {
                EmployeeId = employeeId,
                BenefitId = benefitId,
                EnrollmentDate = DateTime.Now,
                CostToCompany = costToCompany
            };

            await _employeeBenefitRepository.AddEmployeeBenefitAsync(employeeBenefit);
        }

        public async Task<List<EmployeeBenefitDTO>> GetEmployeeBenefitsAsync(int employeeId)
        {
            var employeeBenefits = await _employeeBenefitRepository.GetBenefitsByEmployeeIdAsync(employeeId);
            return employeeBenefits.Select(eb => new EmployeeBenefitDTO
            {
                EmployeeBenefitId = eb.EmployeeBenefitId,
                BenefitId = eb.BenefitId,
                BenefitName = eb.Benefit.BenefitName,
                CostToCompany = eb.CostToCompany,
                EnrollmentDate = eb.EnrollmentDate
            }).ToList();
        }

        public async Task UpdateEmployeeBenefitAsync(int employeeBenefitId, decimal newCostToCompany)
        {
            var employeeBenefit = await _employeeBenefitRepository.GetBenefitsByEmployeeIdAsync(employeeBenefitId);
            if (employeeBenefit == null) throw new Exception("Employee benefit not found");

            employeeBenefit.First().CostToCompany = newCostToCompany;
            await _employeeBenefitRepository.UpdateEmployeeBenefitAsync(employeeBenefit.First());
        }
    }
}
