using HR_System.BLL.Sarvices;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        [HttpGet("LeaveUsageReport")]
        public async Task<IActionResult> GetAverageLeavePerEmployee()
        {
            var report = await _reportService.GetAverageLeavePerEmployeeAsync();
            return Ok(report);
        }
        [HttpGet("PerformanceTrendsReport")]
        public async Task<IActionResult> GetPerformanceTrends()
        {
            var report = await _reportService.GetPerformanceTrendsAsync();
            return Ok(report);
        }
        [HttpGet("GoalCompletionReport")]
        public async Task<IActionResult> GetGoalCompletionRates()
        {
            var report = await _reportService.GetGoalCompletionRatesAsync();
            return Ok(report);
        }
    }
}
