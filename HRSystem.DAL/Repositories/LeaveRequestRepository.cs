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
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public LeaveRequestRepository(ApplicationDbContext context)
        {
            _context = context;
         
        }
        public async Task AddLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            await _context.AddAsync(leaveRequest);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveHistoryAsync(int employeeId)
        {
            return await _context.LeaveRequests
                                .Where(lr => lr.EmployeeId == employeeId)
                                .ToListAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestByIdAsync(int leaveRequestId)
        {
            return await _context.LeaveRequests.FindAsync(leaveRequestId);
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsByStatusAsync(string status)
        {
            return await _context.LeaveRequests
                                 .Where(lr => lr.Status == status)
                                 .ToListAsync();
        }

        public  async Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            await _context.SaveChangesAsync();
        }
    }
}
