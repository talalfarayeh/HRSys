using HRSystem.DAL.Date;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace HRSystem.DAL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Find(id);
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }
        public void AssignEmployeeToDepartment(EmployeeDepartment employeeDepartment)
        {
            _context.EmployeeDepartments.Add(employeeDepartment);
            _context.SaveChanges();
        }

        public void RemoveEmployeeFromDepartment(int employeeId, int departmentId)
        {
            var employeeDepartment = _context.EmployeeDepartments
                .FirstOrDefault(ed => ed.EmployeeId == employeeId && ed.DepartmentId == departmentId);

            if (employeeDepartment != null)
            {
                _context.EmployeeDepartments.Remove(employeeDepartment);
                _context.SaveChanges();
            }
        }
    }
}
