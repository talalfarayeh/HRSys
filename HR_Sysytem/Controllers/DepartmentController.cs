using HR_Sysytem.Date;
using HR_Sysytem.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Sysytem.Controllers
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
        public  IActionResult GetAll()
        {
            try
            {
                return Ok(_context.Departments.OrderBy(x=>x.DepartmentName).ToList());
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
           
        }

         
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_context.Departments.FirstOrDefault(x => x.DepartmentId==id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost("PostSave")]
        public IActionResult PostSave([FromBody] Department model)
        {
            try
            {
                _context.Departments.Add(model);
                _context.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("Edit/{id}")]
        public  IActionResult Edit(int id, [FromBody] Department model)
        {
            try
            {
                var Result = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
                if (Result != null)
                {
                    Result.DepartmentName = model.DepartmentName;
                    _context.Update(Result);
                    _context.SaveChanges();
                    return Ok(Result);
                }

                return BadRequest();
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
                var Result = _context.Departments.FirstOrDefault(c => c.DepartmentId == id);
                if (Result != null)
                {
                    _context.Departments.Remove(Result);
                    _context.SaveChanges();
                    return Ok(Result);
                }
                return BadRequest(Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
