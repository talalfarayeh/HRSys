using HR_System.BLL.Sarvices;
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
        
        [HttpGet("pendingLeaveRequests")]
        public async Task<IActionResult> GetPendingLeaveRequests()
        {
            var leaveRequests = await _leaveRequestService.GetPendingLeaveRequestsAsync();
            return Ok(leaveRequests);
        }

        
        [HttpPost("{LeaveRequestId}/approve")]
        public async Task<IActionResult> ApproveLeaveRequest(int LeaveRequestId)
        {
            await _leaveRequestService.ApproveLeaveRequest(LeaveRequestId);
            return Ok("Leave request approved.");
        }

        
        [HttpPost("RejectLeaveRequest/{LeaveRequestId}/reject")]
        public async Task<IActionResult> RejectLeaveRequest(int LeaveRequestId)
        {
            await _leaveRequestService.RejectLeaveRequest(LeaveRequestId);
            return Ok("Leave request rejected.");
        }

/*        [Authorize(Roles = "Manager")]
*/        [HttpGet("GetTeamPerformanceReviews")]
        public async Task<IActionResult> GetTeamPerformanceReviews()
        {
            var teamPerformanceSummaries = await _performanceReviewService.GetTeamPerformanceSummariesAsync();  
            return Ok(teamPerformanceSummaries);
        }
        
/*        [Authorize(Roles = "Manager")]
*/        [HttpGet("getTeamGoals")]
        public async Task<IActionResult> GetTeamGoals()
        {
             var teamGoals = await _goalService.GetTeamGoalsAsync();  
            return Ok(teamGoals);
        }
    }
}
