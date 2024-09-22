using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
    public interface IRoleRepository
    {

        IEnumerable<Role> GetAllRoles();  
        Role GetRoleById(int id); 
        void AddRole(Role role);  
        void UpdateRole(Role role);  
        void DeleteRole(int id);  
        bool IsRoleSaved(int roleId); 
    }
}
