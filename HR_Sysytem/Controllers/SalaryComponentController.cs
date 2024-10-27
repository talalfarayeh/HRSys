using HR_System.BLL.DTOs.Payroll;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryComponentController : ControllerBase
    {
        private readonly ISalaryComponentService _salaryComponentService;

        public SalaryComponentController(ISalaryComponentService salaryComponentService)
        {
            _salaryComponentService = salaryComponentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSalaryComponent([FromBody] SalaryComponentDTO salaryComponentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _salaryComponentService.AddSalaryComponentAsync(salaryComponentDto);
            return Ok("Salary component added successfully.");
        }
    }
}
