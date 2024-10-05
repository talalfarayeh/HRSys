﻿using HR_System.BLL.Sarvices;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    /*[Authorize(Roles = "Manager")]*/
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerDashboardController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly IPerformanceReviewService _performanceReviewService;
        private readonly IGoalService _goalService;

        public ManagerDashboardController(
            ILeaveRequestService leaveRequestService,
            IPerformanceReviewService performanceReviewService,
            IGoalService goalService)
        {
            _leaveRequestService = leaveRequestService;
            _performanceReviewService = performanceReviewService;
            _goalService = goalService;
        }
        // جلب الطلبات المعلقة للموافقة أو الرفض
        [HttpGet("pendingLeaveRequests")]
        public async Task<IActionResult> GetPendingLeaveRequests()
        {
            var leaveRequests = await _leaveRequestService.GetPendingLeaveRequestsAsync();
            return Ok(leaveRequests);
        }

        // الموافقة على طلب الإجازة
        [HttpPost("{LeaveRequestId}/approve")]
        public async Task<IActionResult> ApproveLeaveRequest(int LeaveRequestId)
        {
            await _leaveRequestService.ApproveLeaveRequest(LeaveRequestId);
            return Ok("Leave request approved.");
        }

        // رفض طلب الإجازة
        [HttpPost("{LeaveRequestId}/reject")]
        public async Task<IActionResult> RejectLeaveRequest(int LeaveRequestId)
        {
            await _leaveRequestService.RejectLeaveRequest(LeaveRequestId);
            return Ok("Leave request rejected.");
        }

/*        [Authorize(Roles = "Manager")]
*/        [HttpGet("GetTeamPerformanceReviews")]
        public async Task<IActionResult> GetTeamPerformanceReviews()
        {
            var teamPerformanceSummaries = await _performanceReviewService.GetTeamPerformanceSummariesAsync();  // بدون managerId
            return Ok(teamPerformanceSummaries);
        }
        // فقط المدراء يمكنهم الوصول إلى هذا الـ Endpoint
/*        [Authorize(Roles = "Manager")]
*/        [HttpGet("GetTeamGoals")]
        public async Task<IActionResult> GetTeamGoals()
        {
            // استدعاء خدمة الأهداف الخاصة بالفريق للمدير
            var teamGoals = await _goalService.GetTeamGoalsAsync();  // لاحظ حذف استخدام managerId
            return Ok(teamGoals);
        }
    }
}