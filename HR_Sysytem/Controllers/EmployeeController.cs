using HR_System.BLL.DTOs;
using HRSystem.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Endpoint لجلب الملف الشخصي للموظف
        [HttpGet("{id}/profile")]
        public IActionResult GetEmployeeProfile(int id)
        {
            try
            {
                var profile = _employeeService.GetEmployeeProfile(id);
                if (profile == null) return NotFound();

                return Ok(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("")]
        public IActionResult PostSave([FromBody] EmployeeDTO model)
        {
            try
            {
                _employeeService.AddEmployee(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] EmployeeDTO model)
        {
            try
            {
                _employeeService.UpdateEmployee(id, model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("search")]
        public IActionResult SearchEmployees([FromQuery] string name, [FromQuery] string email, [FromQuery] string position, [FromQuery] int? departmentId, [FromQuery] int? roleId)
        {
            try
            {
                var employees = _employeeService.SearchEmployees(name, email, position, departmentId, roleId);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
