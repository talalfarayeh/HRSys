using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
     public interface IGoalRepository
    {
        Task AddGoalAsync(Goal goal);
        Task UpdateGoalAsync(Goal goal);
        Task<List<Goal>> GetGoalsByEmployeeIdAsync(int employeeId);

        Task<List<Goal>> GetCurrentGoalsByEmployeeIdAsync(int employeeId);//D
        Task<List<Goal>> GetTeamGoalsAsync();
    }
}
