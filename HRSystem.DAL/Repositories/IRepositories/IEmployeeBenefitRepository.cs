using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
    public interface IEmployeeBenefitRepository
    {
        Task<List<EmployeeBenefit>> GetBenefitsByEmployeeIdAsync(int employeeId);
        Task AddEmployeeBenefitAsync(EmployeeBenefit employeeBenefit);
        Task UpdateEmployeeBenefitAsync(EmployeeBenefit employeeBenefit);
    }
}
