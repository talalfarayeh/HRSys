using HRSystem.DAL.Models;
using System.Collections.Generic;

namespace HRSystem.DAL.Repositories.IRepositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
