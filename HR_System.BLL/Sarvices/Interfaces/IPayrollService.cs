using HR_System.BLL.DTOs.HR_System.BLL.DTOs;
using HR_System.BLL.DTOs.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
     public interface IPayrollService
    {
        Task<PayrollDTO> GeneratePayrollAsync(int employeeId, int workingDays);
        Task<List<PayrollDTO>> GetPayrollHistoryAsync(int employeeId);
        Task ApprovePayrollAsync(int payrollId);
        Task<PayrollDTO> GetPayrollByIdAsync(int payrollId);
    }
}
