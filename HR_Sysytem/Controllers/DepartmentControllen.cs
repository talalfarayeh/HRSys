using HR_System.BLL.DTOs;
using HRSystem.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var departments = _departmentService.GetAllDepartments();
                return Ok(departments);
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
                var department = _departmentService.GetDepartmentById(id);
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("")]
        public IActionResult PostSave([FromBody] DepartmentDTO model)
        {
            try
            {
                _departmentService.AddDepartment(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] DepartmentDTO model)
        {
            try
            {
                _departmentService.UpdateDepartment(id, model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                _departmentService.DeleteDepartment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpPost("{departmentId}/assign/{employeeId}")]
        public IActionResult AssignEmployeeToDepartment(int departmentId, int employeeId)
        {
            try
            {
                _departmentService.AssignEmployeeToDepartment(employeeId, departmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("{departmentId}/remove/{employeeId}")]
        public IActionResult RemoveEmployeeFromDepartment(int departmentId, int employeeId)
        {
            try
            {
                _departmentService.RemoveEmployeeFromDepartment(employeeId, departmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
        [HttpGet("{departmentId}/employees")]
        public IActionResult GetEmployeesByDepartment(int departmentId)
        {
            try
            {
                var employees = _departmentService.GetEmployeesByDepartment(departmentId);
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

 
 