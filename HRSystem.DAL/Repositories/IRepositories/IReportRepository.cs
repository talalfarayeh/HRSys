using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
     public interface IReportRepository
    {
        Task<List<Employee>> GetEmployeesWithLeaveDataAsync();
        Task<List<Employee>> GetEmployeesWithPerformanceDataAsync();
        Task<List<Employee>> GetEmployeesWithGoalsDataAsync();
    }
}
