using HR_System.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
     public interface IGoalService
    {
        Task SubmitGoal(GoalDTO goalDto);

        Task UpdateGoal(GoalDTO goalDto);
        Task<List<GoalDTO>> GetGoalsByEmployeeId(int employeeId);
        Task<List<GoalDTO>> GetCurrentGoalsAsync(int employeeId);
        Task<List<GoalDTO>> GetTeamGoalsAsync();
    }
}
