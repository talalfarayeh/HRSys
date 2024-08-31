using HR_System.BLL.DTOs;
using HRSystem.DAL.Date;
using Microsoft.AspNetCore.Mvc;
 
namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var departments = _context.Departments.OrderBy(x => x.DepartmentName)
                    .Select(d => new DepartmentDTO
                    {
                        DepartmentId = d.DepartmentId,
                        DepartmentName = d.DepartmentName
                    }).ToList();
                return Ok(departments);
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
                var department = _context.Departments
                    .Where(x => x.DepartmentId == id)
                    .Select(d => new DepartmentDTO
                    {
                        DepartmentId = d.DepartmentId,
                        DepartmentName = d.DepartmentName
                    }).FirstOrDefault();

                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("PostSave")]
        public IActionResult PostSave([FromBody] DepartmentDTO model)
        {
            try
            {
                var department = new Department
                {
                    DepartmentName = model.DepartmentName
                };

                _context.Departments.Add(department);
                _context.SaveChanges();
                return Ok(department);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Edit/{id}")]
        public IActionResult Edit(int id, [FromBody] DepartmentDTO model)
        {
            try
            {
                var result = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
                if (result != null)
                {
                    result.DepartmentName = model.DepartmentName;
                    _context.Update(result);
                    _context.SaveChanges();
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var result = _context.Departments.FirstOrDefault(c => c.DepartmentId == id);
                if (result != null)
                {
                    _context.Departments.Remove(result);
                    _context.SaveChanges();
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
