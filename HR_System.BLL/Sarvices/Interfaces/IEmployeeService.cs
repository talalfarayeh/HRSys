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
        IEnumerable<EmployeeDTO> SearchEmployees(string name, string email, string position, int? departmentId, int? roleId);
       
        EmployeeProfileDTO GetEmployeeProfile(int id);

        public void UpdateEmployeeProfile(EmployeeProfileDTO employeeProfile);
    }
}
