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
        IEnumerable<RoleDTO> GetAllRoles(); // جلب جميع الأدوار
        RoleDTO GetRoleById(int id); // جلب دور معين حسب الـ ID
        void AddRole(RoleDTO role); // إضافة دور جديد
        void UpdateRole(int id, RoleDTO role); // تحديث دور
        void DeleteRole(int id); // حذف دور
        bool IsRoleSaved(int roleId); // التحقق من وجود دور معين
    }
}
