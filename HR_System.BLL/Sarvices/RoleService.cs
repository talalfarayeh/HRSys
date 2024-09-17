using HR_System.BLL.DTOs;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
     public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        public IEnumerable<RoleDTO> GetAllRoles() 
        {
            var roles = _roleRepository.GetAllRoles();
            return roles.Select(r => new RoleDTO
            {
                RoleId = r.RoleId,
                RoleName = r.RoleName,

            }).ToList();

        
        }
        public RoleDTO GetRoleById(int id)
        {
            var role = _roleRepository.GetRoleById(id);
            return new RoleDTO
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };
        }
        public void AddRole(RoleDTO role)
        {
            var newRole = new Role
            {
                RoleName = role.RoleName
            };
            _roleRepository.AddRole(newRole);
        }

        public void UpdateRole(int id, RoleDTO role)
        {
            var existingRole = _roleRepository.GetRoleById(id);
            if (existingRole != null)
            {
                existingRole.RoleName = role.RoleName;
                _roleRepository.UpdateRole(existingRole);
            }
        }
        public void DeleteRole(int id)
        {
            _roleRepository.DeleteRole(id);
        }

        public bool IsRoleSaved(int roleId)
        {
            return _roleRepository.IsRoleSaved(roleId);
        }







    }
}
