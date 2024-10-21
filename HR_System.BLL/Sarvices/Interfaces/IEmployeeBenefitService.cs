using HR_System.BLL.DTOs.Benefit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface IEmployeeBenefitService
    {
        Task EnrollEmployeeInBenefitAsync(int employeeId, int benefitId, decimal costToCompany);
        Task UpdateEmployeeBenefitAsync(int employeeBenefitId, decimal newCostToCompany);
        Task<List<EmployeeBenefitDTO>> GetEmployeeBenefitsAsync(int employeeId);
    }
}
