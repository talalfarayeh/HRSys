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
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly INotificationService _notificationService;

        public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository, INotificationService notificationService)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _notificationService = notificationService;
        }

        public async Task SubmitLeaveRequest(LeaveRequestDTO leaveRequestDto)
        {
            var leaveRequest = new LeaveRequest
            {
                EmployeeId = leaveRequestDto.EmployeeId,
                StartDate = leaveRequestDto.StartDate,
                EndDate = leaveRequestDto.EndDate,
                LeaveType = leaveRequestDto.LeaveType,
                Status = "Pending",
                RequestDate = DateTime.Now,


            };
            await _leaveRequestRepository.AddLeaveRequestAsync(leaveRequest);
            await _notificationService.NotifyManager(leaveRequestDto.EmployeeId, "New leave request submitted.");

        }
        public async Task ApproveLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(leaveRequestId);
            if (leaveRequest == null) throw new Exception("Leave request not found.");
            leaveRequest.Status = "Approved";
            leaveRequest.RequestDate = DateTime.Now;
            await _leaveRequestRepository.UpdateLeaveRequestAsync(leaveRequest);
            await _notificationService.NotifyEmployee(leaveRequest.EmployeeId, "Your leave request has been approved.");
        }
        public async Task RejectLeaveRequest(int leaveRequestId)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestByIdAsync(leaveRequestId);
            if (leaveRequest == null) throw new Exception("Leave request not found.");

            leaveRequest.Status = "Rejected";
            leaveRequest.ApprovalDate = DateTime.Now;
            await _leaveRequestRepository.UpdateLeaveRequestAsync(leaveRequest);
            await _notificationService.NotifyEmployee(leaveRequest.EmployeeId, "Your leave request has been rejected.");
        }

        

        public async Task<List<LeaveRequestDTO>> GetLeaveRequestsByStatus(string status)
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveRequestsByStatusAsync(status);
            return leaveRequests.Select(lr => new LeaveRequestDTO
            {
                LeaveRequestId = lr.LeaveRequestId,
                EmployeeId = lr.EmployeeId,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                LeaveType = lr.LeaveType,
                Status = lr.Status
            }).ToList();
        }
        public async Task<List<LeaveRequestDTO>> GetLeaveHistory(int employeeId)
        {
            var leaveRequests = await _leaveRequestRepository.GetLeaveHistoryAsync(employeeId);
            return leaveRequests.Select(lr => new LeaveRequestDTO
            {
                LeaveRequestId = lr.LeaveRequestId,
                EmployeeId = lr.EmployeeId,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                LeaveType = lr.LeaveType,
                Status = lr.Status
            }).ToList();
        }
        public async Task<int> GetLeaveBalanceAsync(int employeeId)
        {
            return await _leaveRequestRepository.GetLeaveBalanceAsync(employeeId);
        }
        public async Task<List<LeaveRequestDTO>> GetUpcomingLeavesAsync(int employeeId)
        {
            var upcomingLeaves = await _leaveRequestRepository.GetUpcomingLeavesAsync(employeeId);
            return upcomingLeaves.Select(lr => new LeaveRequestDTO
            {
                LeaveRequestId = lr.LeaveRequestId,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                LeaveType = lr.LeaveType
            }).ToList();

        }
         public async Task<List<LeaveRequestDTO>> GetPendingLeaveRequestsAsync()
        {
            var leaveRequests = await _leaveRequestRepository.GetPendingLeaveRequestsAsync();
            return leaveRequests.Select(lr => new LeaveRequestDTO 
            {
                LeaveRequestId = lr.LeaveRequestId,
                EmployeeId = lr.EmployeeId,
                StartDate = lr.StartDate,
                EndDate = lr.EndDate,
                LeaveType = lr.LeaveType,
                Status = lr.Status

            } ).ToList();
        }



    }
}
