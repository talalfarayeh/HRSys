using HR_Sysytem.Date;
using HR_Sysytem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Sysytem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_context.Employees.OrderBy(x => x.LastName).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_context.Employees.FirstOrDefault(x => x.EmployeeId == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostSave")]
        public IActionResult PostSave([FromBody] Employee model)
        {
            try
            {
                _context.Employees.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, [FromBody] Employee model)
        {
            try
            {
                var result = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
                if (result != null)
                {
                    result.FirstName = model.FirstName;
                    result.LastName = model.LastName;
                    result.Email = model.Email;
                    result.DateOfBirth = model.DateOfBirth;
                    result.Position = model.Position;
                    result.DateHired = model.DateHired;
                    _context.Update(result);
                    _context.SaveChanges();
                    return Ok(result);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var result = _context.Employees.FirstOrDefault(c => c.EmployeeId == id);
                if (result != null)
                {
                    _context.Employees.Remove(result);
                    _context.SaveChanges();
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
