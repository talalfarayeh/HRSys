using HR_System.BLL.DTOs;
using System.Collections.Generic;

namespace HRSystem.BLL.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);
        void AddEmployee(EmployeeDTO employee);
        void UpdateEmployee(int id, EmployeeDTO employee);
        void DeleteEmployee(int id);
    }
}
