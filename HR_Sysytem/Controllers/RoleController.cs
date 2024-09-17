using HR_System.BLL.DTOs;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            roleService = _roleService;
            
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            try
            {
                var roles = _roleService.GetAllRoles();
                return Ok(roles);
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
                var role = _roleService.GetRoleById(id);
                if (role == null) return NotFound();
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // إضافة دور جديد
        [HttpPost("")]
        public IActionResult AddRole([FromBody] RoleDTO role)
        {
            try
            {
                _roleService.AddRole(role);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // تعديل دور معين
        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, [FromBody] RoleDTO role)
        {
            try
            {
                _roleService.UpdateRole(id, role);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // حذف دور معين
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            try
            {
                _roleService.DeleteRole(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
