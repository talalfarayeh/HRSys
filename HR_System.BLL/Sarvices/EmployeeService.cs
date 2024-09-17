using HR_System.BLL.DTOs;
using HRSystem.DAL.Models;
using HRSystem.BLL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using HRSystem.DAL.Repositories.IRepositories;

namespace HRSystem.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll().OrderBy(e => e.FirstName);
            return employees.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                Position = e.Position,
                DateHired = e.DateHired
            }).ToList();
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return new EmployeeDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position,
                DateHired = employee.DateHired
            };
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            var newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position,
                DateHired = employee.DateHired
            };
            _employeeRepository.Add(newEmployee);
        }

        public void UpdateEmployee(int id, EmployeeDTO employee)
        {
            var existingEmployee = _employeeRepository.GetById(id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Email = employee.Email;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                existingEmployee.Position = employee.Position;
                existingEmployee.DateHired = employee.DateHired;
                _employeeRepository.Update(existingEmployee);
            }
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);
        }
        public IEnumerable<EmployeeDTO> SearchEmployees(string name, string email, string position, int? departmentId, int? roleId) 
        {
            var query = _employeeRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name) || e.LastName.Contains(name));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(e => e.Email.Contains(email));
            }
            if (!string.IsNullOrEmpty(position))
            {
                query = query.Where(e => e.Position.Contains(position));
            }
            if (departmentId.HasValue)
            {
                query = query.Where(e => e.EmployeeDepartments.Any(ed => ed.DepartmentId == departmentId));
            }
            if (roleId.HasValue)
            {
                query = query.Where(e => e.EmployeeRoles.Any(er => er.RoleId == roleId));
            }
            return query.Select(e => new EmployeeDTO
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                Position = e.Position,
                DateHired = e.DateHired
            }).ToList();



        }
        public EmployeeProfileDTO GetEmployeeProfile(int id)
        {
            // جلب الموظف من المستودع
            var employee = _employeeRepository.GetById(id);
            if (employee == null) return null;

            // تجميع بيانات الملف الشخصي مع الأقسام والأدوار
            return new EmployeeProfileDTO
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                Position = employee.Position,
                DateHired = employee.DateHired,

                // جلب الأقسام التي ينتمي إليها الموظف
                Departments = employee.EmployeeDepartments
                                      .Select(ed => ed.Department.DepartmentName)
                                      .ToList(),

                // جلب الأدوار التي يمتلكها الموظف
                Roles = employee.EmployeeRoles
                               .Select(er => er.Role.RoleName)
                               .ToList()
            };
        }

    }
}
