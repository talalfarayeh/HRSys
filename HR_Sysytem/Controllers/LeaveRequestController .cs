using HR_System.BLL.DTOs;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequestService;

        public LeaveRequestController(ILeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;
        }
        [HttpPost("submitLeaveRequest")]
        public async Task<IActionResult> SubmitLeaveRequest([FromBody]LeaveRequestDTO leaveRequestDTO)
        {
          await _leaveRequestService.SubmitLeaveRequest(leaveRequestDTO);
            return Ok("Leave request submitted.");
        
        
        }

        [HttpPost("{LeaveRequestId}/approve")]
        public async Task<IActionResult> ApproveLeaveRequest(int LeaveRequestId)
        {
            await _leaveRequestService.ApproveLeaveRequest(LeaveRequestId);
            return Ok("Leave request approved.");
        }
        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectLeaveRequest(int id)
        {
            await _leaveRequestService.RejectLeaveRequest(id);
            return Ok("Leave request rejected.");
        }
        [HttpGet("getLeaveRequestsByStatus/{status}")]
        public async Task<IActionResult> GetLeaveRequestsByStatus(string status)
        {
            var leaveRequests = await _leaveRequestService.GetLeaveRequestsByStatus(status);
            return Ok(leaveRequests);
        }
        [HttpGet("getLeaveHistory/{employeeId}")]
        public async Task<IActionResult> GetLeaveHistory(int employeeId)
        {
            var leaveHistory = await _leaveRequestService.GetLeaveHistory(employeeId);
            return Ok(leaveHistory);
        }
    }
}
