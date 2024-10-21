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
    public class EmployeeBenefitRepository : IEmployeeBenefitRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeBenefitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeBenefit>> GetBenefitsByEmployeeIdAsync(int employeeId)
        {
            return await _context.EmployeeBenefits.Include(e=>e.Benefit).Where(eb => eb.EmployeeId == employeeId)
                .ToListAsync();

        }
        public async Task AddEmployeeBenefitAsync(EmployeeBenefit employeeBenefit)
        {
            await _context.EmployeeBenefits.AddAsync(employeeBenefit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeBenefitAsync(EmployeeBenefit employeeBenefit)
        {
            _context.EmployeeBenefits.Update(employeeBenefit);
            await _context.SaveChangesAsync();
        }
    }
}
