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
     public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Employee>> GetEmployeesWithLeaveDataAsync()
        {
            return await _context.Employees
                .Include(e => e.LeaveRequests)   
                .ToListAsync();
        }
        public async Task<List<Employee>> GetEmployeesWithPerformanceDataAsync()
        {
            return await _context.Employees
                .Include(e => e.PerformanceReviews)
                .ToListAsync();
        }
        public async Task<List<Employee>> GetEmployeesWithGoalsDataAsync()
        {
            return await _context.Employees
                .Include(e => e.Goals)
                .ToListAsync();
        }
    }
}
