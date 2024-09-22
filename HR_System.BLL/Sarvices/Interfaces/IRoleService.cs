using HR_System.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<RoleDTO> GetAllRoles();  
        RoleDTO GetRoleById(int id);  
        void AddRole(RoleDTO role);  
        void UpdateRole(int id, RoleDTO role);  
        void DeleteRole(int id);  
        bool IsRoleSaved(int roleId);  
    }
}
