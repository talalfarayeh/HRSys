using HRSystem.DAL.Date;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories
{
    public class SalaryComponentRepository : ISalaryComponentRepository
    {
        private readonly ApplicationDbContext _context;

        public SalaryComponentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalaryComponent>> GetSalaryComponentsByEmployeeIdAsync(int employeeId)
        {
            return await _context.SalaryComponents
                .Where(sc => sc.EmployeeId == employeeId)
                .ToListAsync();
        }
    }

}
