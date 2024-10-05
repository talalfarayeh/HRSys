using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
    public interface IPerformanceReviewRepository
    {
        Task AddPerformanceReviewAsync(PerformanceReview review);
        Task<List<PerformanceReview>> GetPerformanceReviewsByEmployeeIdAsync(int employeeId);
        Task<List<PerformanceReview>> GetPerformanceReviewHistoryAsync(int employeeId);//D
        Task<List<PerformanceReview>> GetTeamPerformanceReviewsAsync();  // حذف managerId

    }
}
