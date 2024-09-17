using HR_System.BLL.DTOs;
using HRSystem.DAL.Models;
using HRSystem.BLL.Services;
using HRSystem.DAL.Repositories.IRepositories;

namespace HRSystem.BLL.Interfaces
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<DepartmentDTO> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAll().OrderBy(d => d.DepartmentName);
            return departments.Select(d => new DepartmentDTO
            {
                DepartmentId = d.DepartmentId,
                DepartmentName = d.DepartmentName,
                Description = d.Description
            }).ToList();
        }

        public DepartmentDTO GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetById(id);
            return new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };
        }

        public void AddDepartment(DepartmentDTO department)
        {
            var newDepartment = new Department
            {
                DepartmentName = department.DepartmentName,
                Description = department.Description
            };
            _departmentRepository.Add(newDepartment);
        }

        public void UpdateDepartment(int id, DepartmentDTO department)
        {
            var existingDepartment = _departmentRepository.GetById(id);
            if (existingDepartment != null)
            {
                existingDepartment.DepartmentName = department.DepartmentName;
                existingDepartment.Description = department.Description;
                _departmentRepository.Update(existingDepartment);
            }
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.Delete(id);
        }
        public void AssignEmployeeToDepartment(int employeeId, int departmentId)
        {
            var employeeDepartment = new EmployeeDepartment
            {
                EmployeeId = employeeId,
                DepartmentId = departmentId
            };
            _departmentRepository.AssignEmployeeToDepartment(employeeDepartment);
        }

        public void RemoveEmployeeFromDepartment(int employeeId, int departmentId)
        {
            _departmentRepository.RemoveEmployeeFromDepartment(employeeId, departmentId);
        }
    }
}
