using HR_System.BLL.DTOs;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformanceReviewController : ControllerBase
    {
        private readonly IPerformanceReviewService _performanceReviewService;

        public PerformanceReviewController(IPerformanceReviewService performanceReviewService)
        {
            _performanceReviewService = performanceReviewService;
        }

        [HttpPost("submitReview")]
        public async Task<IActionResult> SubmitReview([FromBody] PerformanceReviewDTO reviewDto)
        {
            await _performanceReviewService.SubmitPerformanceReview(reviewDto);
            return Ok("Performance review submitted successfully.");
        }

        [HttpGet("GetEmployeePerformanceReviews/{employeeId}")]
        public async Task<IActionResult> GetEmployeePerformanceReviews(int employeeId)
        {
            var reviews = await _performanceReviewService.GetPerformanceReviewsByEmployeeId(employeeId);
            return Ok(reviews);
        }
    }
}
