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

        IEnumerable<Role> GetAllRoles(); // جلب جميع الأدوار
        Role GetRoleById(int id); // جلب دور معين حسب الـ ID
        void AddRole(Role role); // إضافة دور جديد
        void UpdateRole(Role role); // تحديث دور موجود
        void DeleteRole(int id); // حذف دور
        bool IsRoleSaved(int roleId); // التحقق من وجود دور معين
    }
}
