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
        public async Task<List<Employee>> GetAverageLeavePerEmployeeAsync()
        {
             var employeesWithLeaveData = await _context.Employees
                .Include(e => e.LeaveRequests)  
                .Where(e => e.LeaveRequests.Any(lr => lr.Status == "Approved"))   
                .Select(e => new Employee
                {
                    EmployeeId = e.EmployeeId,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                
                    AverageLeaveTaken = e.LeaveRequests
                        .Where(lr => lr.Status == "Approved")
                        .Average(lr => EF.Functions.DateDiffDay(lr.StartDate, lr.EndDate))   
                })
                .ToListAsync();

            return employeesWithLeaveData;
        }
        public async Task<List<Employee>> GetEmployeesWithPerformanceDataAsync()
        {
            return await _context.Employees
                .Include(e => e.PerformanceReviews)
                .Include(e => e.EmployeeDepartments)  
                .ThenInclude(ed => ed.Department)     
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
