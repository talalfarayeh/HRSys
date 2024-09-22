using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.DAL.Models;

namespace HRSystem.DAL.Repositories.IRepositories
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        void Add(Department department);
        void Update(Department department);
        void Delete(int id);
        void AssignEmployeeToDepartment(EmployeeDepartment employeeDepartment);
        void RemoveEmployeeFromDepartment(int employeeId, int departmentId);
        IEnumerable<Employee> GetEmployeesByDepartment(int departmentId);
    }
}

