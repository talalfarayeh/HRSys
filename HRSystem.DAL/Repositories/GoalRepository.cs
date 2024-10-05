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
    public class GoalRepository : IGoalRepository
    {
        private readonly ApplicationDbContext _context;
        public GoalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddGoalAsync(Goal goal)
        {
            await _context.AddAsync(goal);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateGoalAsync(Goal goal)
        {
            _context.Goals.Update(goal);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Goal>> GetGoalsByEmployeeIdAsync(int employeeId)
        {
          return   await _context.Goals.Where(g=>g.EmployeeId == employeeId).ToListAsync();
        }
        public async Task<List<Goal>> GetCurrentGoalsByEmployeeIdAsync(int employeeId)
        {
            return await _context.Goals
                                 .Where(g => g.EmployeeId == employeeId && !g.IsCompleted)
                                 .ToListAsync();
        }
        public async Task<List<Goal>> GetTeamGoalsAsync()
        {
            // استرجاع الأهداف الخاصة بالفريق بدون الحاجة لاستخدام managerId
            return await _context.Goals
                .Where(g => g.Employee.EmployeeRoles.Any(er => er.Role.RoleName == "Manager"))  // التأكد أن الموظفين مرتبطين بدور "Manager"
                .Include(g => g.Employee) // تضمين معلومات الموظف
                .ToListAsync();
        }

    }
}
