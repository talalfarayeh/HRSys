using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
     public interface ILeaveRequestRepository
    {
        Task AddLeaveRequestAsync(LeaveRequest leaveRequest);
        Task UpdateLeaveRequestAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest> GetLeaveRequestByIdAsync(int leaveRequestId);
        Task<List<LeaveRequest>> GetLeaveRequestsByStatusAsync(string status);
        Task<List<LeaveRequest>> GetLeaveHistoryAsync(int employeeId);
        Task<int> GetLeaveBalanceAsync(int employeeId);//D
        Task<List<LeaveRequest>> GetUpcomingLeavesAsync(int employeeId);//D
        Task<List<LeaveRequest>> GetPendingLeaveRequestsAsync();//DM
     



    }
}
