using HR_System.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
   public interface IPerformanceReviewService 
    {
        Task SubmitPerformanceReview(PerformanceReviewDTO reviewDto);
        Task<List<PerformanceReviewDTO>> GetPerformanceReviewsByEmployeeId(int employeeId);
        Task<List<PerformanceReviewDTO>> GetPerformanceReviewHistoryAsync(int employeeId);
        Task<List<PerformanceReviewDTO>> GetTeamPerformanceSummariesAsync();  // حذف managerId
    }
}
