using HR_System.BLL.DTOs;
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
    public class PerformanceReviewService : IPerformanceReviewService
    {
        private readonly IPerformanceReviewRepository _performanceReviewRepository;
        public PerformanceReviewService(IPerformanceReviewRepository performanceReviewRepository)
        {
            _performanceReviewRepository = performanceReviewRepository;
        }
        public async Task SubmitPerformanceReview(PerformanceReviewDTO reviewDto)
        {
            var review = new PerformanceReview
            {
                EmployeeId = reviewDto.EmployeeId,
                ReviewerId = reviewDto.ReviewerId,
                ReviewDate = reviewDto.ReviewDate,
                Score = reviewDto.Score,
                Comments = reviewDto.Comments


            };
            await _performanceReviewRepository.AddPerformanceReviewAsync(review);
        }
        public async Task<List<PerformanceReviewDTO>> GetPerformanceReviewsByEmployeeId(int employeeId)
        {
            var review = await _performanceReviewRepository.GetPerformanceReviewsByEmployeeIdAsync(employeeId);
            return review.Select(r => new PerformanceReviewDTO
            {
                EmployeeId = r.EmployeeId,
                ReviewerId = r.ReviewerId,
                ReviewDate = r.ReviewDate,
                Score = r.Score,
                Comments = r.Comments



            }).ToList();
        }
        public async Task<List<PerformanceReviewDTO>> GetPerformanceReviewHistoryAsync(int employeeId)
        {
            var reviews = await _performanceReviewRepository
                .GetPerformanceReviewHistoryAsync(employeeId);
            return reviews.Select(r => new PerformanceReviewDTO
            {

                ReviewerId = r.ReviewerId,
                ReviewDate = r.ReviewDate,
                Score = r.Score,
                Comments = r.Comments




            }).ToList();

        }
        public async Task<List<PerformanceReviewDTO>> GetTeamPerformanceSummariesAsync()
        {
            var teamReviews = await _performanceReviewRepository.GetTeamPerformanceReviewsAsync();

            return teamReviews.Select(r => new PerformanceReviewDTO
            {
                EmployeeId = r.EmployeeId,
                ReviewerId = r.ReviewerId,
                ReviewDate = r.ReviewDate,
                Score = r.Score,
                Comments = r.Comments,
                EmployeeName = r.Employee.FirstName + " " + r.Employee.LastName, // تضمين اسم الموظف
                ReviewerName = r.Reviewer.FirstName + " " + r.Reviewer.LastName  // تضمين اسم المراجع (المدير)
            }).ToList();
        }
    }
}
