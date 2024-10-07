using HRSystem.DAL.Date;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories
{
    public class PerformanceReviewRepository : IPerformanceReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public PerformanceReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddPerformanceReviewAsync(PerformanceReview review)
        {
            await _context.PerformanceReviews.AddAsync(review);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PerformanceReview>> GetPerformanceReviewsByEmployeeIdAsync(int employeeId)
        {
            return await _context.PerformanceReviews.Where(pr => pr.EmployeeId == employeeId).ToListAsync();
        }
        public async Task<List<PerformanceReview>> GetPerformanceReviewHistoryAsync(int employeeId)
        {
            return await _context.PerformanceReviews.Where(pr => pr.EmployeeId == employeeId).ToListAsync();
          
        }

 
        public async Task<List<PerformanceReview>> GetTeamPerformanceReviewsAsync()
        {
            return await _context.PerformanceReviews

              .Include(pr => pr.Employee)   
            .Include(pr => pr.Reviewer)   
            .ToListAsync();
        }
    }
}
