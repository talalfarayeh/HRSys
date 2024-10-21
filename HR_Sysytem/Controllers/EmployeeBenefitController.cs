using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBenefitController : ControllerBase
    {
        private readonly IEmployeeBenefitService _employeeBenefitService;

        public EmployeeBenefitController(IEmployeeBenefitService employeeBenefitService)
        {
            _employeeBenefitService = employeeBenefitService;
        }

        [HttpPost("{employeeId}/enroll/{benefitId}")]
        public async Task<IActionResult> EnrollEmployeeInBenefit(int employeeId, int benefitId, [FromBody] decimal costToCompany)
        {
            await _employeeBenefitService.EnrollEmployeeInBenefitAsync(employeeId, benefitId, costToCompany);
            return Ok("Employee enrolled in benefit successfully.");
        }
        [HttpPut("{employeeBenefitId}/update")]
        public async Task<IActionResult> UpdateEmployeeBenefit(int employeeBenefitId, [FromBody] decimal newCostToCompany)
        {
            await _employeeBenefitService.UpdateEmployeeBenefitAsync(employeeBenefitId, newCostToCompany);
            return Ok("Employee benefit updated successfully.");
        }
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeBenefits(int employeeId)
        {
            var employeeBenefits = await _employeeBenefitService.GetEmployeeBenefitsAsync(employeeId);
            return Ok(employeeBenefits);
        }
    }

}
