using HR_System.BLL.DTOs;
using System.Collections.Generic;


namespace HRSystem.BLL.Services
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentDTO> GetAllDepartments();
        DepartmentDTO GetDepartmentById(int id);
        void AddDepartment(DepartmentDTO department);
        void UpdateDepartment(int id, DepartmentDTO department);
        void DeleteDepartment(int id);
        void AssignEmployeeToDepartment(int employeeId, int departmentId);
        void RemoveEmployeeFromDepartment(int employeeId, int departmentId);
    }
}
