using HR_System.BLL.DTOs;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;
        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;

        }
        [HttpPost]
        public async Task<IActionResult> SubmitGoal([FromBody] GoalDTO goalDTO)
        {
            await _goalService.SubmitGoal(goalDTO);
            return Ok("Goal submitted successfully.");
        }
        [HttpPut("updatGoal/{goalId}")]
        public async Task<IActionResult> UpdatGoal(int goalId, [FromBody] GoalDTO goalDTO)
        {
            goalDTO.GoalId = goalId;
            await _goalService.UpdateGoal(goalDTO);
            return Ok("Goal updated successfully.");

        }
        [HttpGet("getEmployeeGoals/{employeeId}")]
        public async Task<IActionResult> GetEmployeeGoals(int employeeId)
        {
            var goals = await _goalService.GetGoalsByEmployeeId(employeeId);
            return Ok(goals);



        }
    }
}
