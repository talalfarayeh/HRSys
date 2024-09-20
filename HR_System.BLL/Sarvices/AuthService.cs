using HRSystem.BLL.Interfaces;
using HRSystem.DAL.Repositories.IRepositories;
using HRSystem.DAL.Models;
using HR_System.BLL.DTOs;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using HR_System.BLL.Sarvices.Interfaces;

namespace HRSystem.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        // طريقة المصادقة: التحقق من اسم المستخدم وكلمة المرور
        public EmployeeDTO Authenticate(string username, string password)
        {
            // تشفير كلمة المرور قبل التحقق
          /*  var passwordHash = HashPassword(password);*/

            // البحث عن الموظف في قاعدة البيانات باستخدام اسم المستخدم وكلمة المرور
            var employee = _authRepository.GetEmployeeByUsernameAndPassword(username, password);

            // إذا لم يتم العثور على الموظف، إرجاع null
            if (employee == null) return null;

            // تحويل كائن Employee إلى EmployeeDTO وإرجاعه
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Position = employee.Position,
                DateHired = employee.DateHired,
                // جلب الأدوار المرتبطة بالموظف
                Roles = employee.EmployeeRoles.Select(er => er.Role.RoleName).ToList()
            };
        }

        // دالة لتشفير كلمة المرور باستخدام SHA256
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
