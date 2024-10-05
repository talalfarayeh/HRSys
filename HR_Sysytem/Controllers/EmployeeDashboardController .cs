using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDashboardController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;
        private readonly IPerformanceReviewService _performanceReviewService;
        private readonly IGoalService _goalService;

        public EmployeeDashboardController(
            ILeaveRequestService leaveRequestService,
            IPerformanceReviewService performanceReviewService,
            IGoalService goalService)
        {
            _leaveRequestService = leaveRequestService;
            _performanceReviewService = performanceReviewService;
            _goalService = goalService;
        }
        [HttpGet("{employeeId}/leave-balance")]
        public async Task<IActionResult> GetLeaveBalance(int employeeId)
        {
            var leaveBalance = await _leaveRequestService.GetLeaveBalanceAsync(employeeId);
            return Ok(leaveBalance);
        }

        [HttpGet("{employeeId}/upcoming-leaves")]
        public async Task<IActionResult> GetUpcomingLeaves(int employeeId)
        {
            var upcomingLeaves = await _leaveRequestService.GetUpcomingLeavesAsync(employeeId);
            return Ok(upcomingLeaves);
        }

        [HttpGet("{employeeId}/performance-reviews")]
        public async Task<IActionResult> GetPerformanceReviewHistory(int employeeId)
        {
            var reviews = await _performanceReviewService.GetPerformanceReviewHistoryAsync(employeeId);
            return Ok(reviews);
        }
        [HttpGet("{employeeId}/current-goals")]
        public async Task<IActionResult> GetCurrentGoals(int employeeId)
        {
            var goals = await _goalService.GetCurrentGoalsAsync(employeeId);
            return Ok(goals);
        }



    }
}
