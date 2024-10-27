using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
    public interface IPayrollRepository
    {
        Task AddPayrollAsync(Payroll payroll);
        Task<List<Payroll>> GetPayrollHistoryByEmployeeIdAsync(int employeeId);
        Task<Payroll> GetPayrollByIdAsync(int payrollId);
        Task ApprovePayrollAsync(int payrollId);
        Task<List<Payroll>> GetPayrollsForYearAsync(int year);

    }
}
