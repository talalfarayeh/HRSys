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

         
        public EmployeeDTO Authenticate(string username, string password)
        {
           /*  var passwordHash = HashPassword(password);*/

             var employee = _authRepository.GetEmployeeByUsernameAndPassword(username, password);

             if (employee == null) return null;

             return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Position = employee.Position,
                DateHired = employee.DateHired,
                Username = employee.Username,
                PasswordHash = employee.PasswordHash,
                 Roles = employee.EmployeeRoles.Select(er => er.Role.RoleName).ToList()
            };
        }

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
