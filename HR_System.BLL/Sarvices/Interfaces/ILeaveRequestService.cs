using HR_System.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface ILeaveRequestService
    {
        Task SubmitLeaveRequest(LeaveRequestDTO leaveRequestDto);
        Task ApproveLeaveRequest(int leaveRequestId);
        Task RejectLeaveRequest(int leaveRequestId);
        Task<List<LeaveRequestDTO>> GetLeaveRequestsByStatus(string status);
        Task<List<LeaveRequestDTO>> GetLeaveHistory(int employeeId);
        Task<int> GetLeaveBalanceAsync(int employeeId);
        Task<List<LeaveRequestDTO>> GetUpcomingLeavesAsync(int employeeId);
        Task<List<LeaveRequestDTO>> GetPendingLeaveRequestsAsync();
    }
}
