using HR_System.BLL.DTOs;
using System.Collections.Generic;

namespace HR_Sysytem.Services
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);
        void AddEmployee(EmployeeDTO employee);
        void UpdateEmployee(EmployeeDTO employee);
        void DeleteEmployee(int id);
    }
}
