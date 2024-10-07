using HR_System.BLL.DTOs.ReportDTO;
using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface IReportService
    {
        Task<List<AverageLeaveTakenDTO>> GetAverageLeavePerEmployeeAsync();
        Task<List<DepartmentPerformanceDTO>> GetPerformanceTrendsAsync();
        Task<List<EmployeeGoalCompletionDTO>> GetGoalCompletionRatesAsync();
    }
}
