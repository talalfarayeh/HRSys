using HR_System.BLL.DTOs;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
    public class GoalService : IGoalService
    {

        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }
        public async Task SubmitGoal(GoalDTO goalDto)
        {
            var goal = new Goal
            {
                EmployeeId = goalDto.EmployeeId,
                GoalDescription = goalDto.GoalDescription,
                TargetDate = goalDto.TargetDate,
                IsCompleted = goalDto.IsCompleted


            };
            await _goalRepository.AddGoalAsync(goal);
        }

        public async Task UpdateGoal(GoalDTO goalDto)
        {
            var goal = new Goal
            {
                GoalId = goalDto.GoalId,
                EmployeeId = goalDto.EmployeeId,
                GoalDescription = goalDto.GoalDescription,
                TargetDate = goalDto.TargetDate,
                IsCompleted = goalDto.IsCompleted
            };
            await _goalRepository.UpdateGoalAsync(goal);
        }
        public async Task<List<GoalDTO>> GetGoalsByEmployeeId(int employeeId)
        {
            var goal = await _goalRepository.GetGoalsByEmployeeIdAsync(employeeId);
            return goal.Select(g => new GoalDTO
            {
                GoalId = g.EmployeeId,
                EmployeeId = g.EmployeeId,
                GoalDescription = g.GoalDescription,
                TargetDate = g.TargetDate,
                IsCompleted = g.IsCompleted

            }).ToList();
        }
        public async Task<List<GoalDTO>> GetCurrentGoalsAsync(int employeeId)
        {
            var goals = await _goalRepository.GetCurrentGoalsByEmployeeIdAsync(employeeId);
            return goals.Select(g => new GoalDTO
            {
                GoalId = g.GoalId,
                GoalDescription = g.GoalDescription,
                TargetDate = g.TargetDate,
                IsCompleted = g.IsCompleted
            }).ToList();
        }
        public async Task<List<GoalDTO>> GetTeamGoalsAsync()
        {
           
            var goals = await _goalRepository.GetTeamGoalsAsync();

            return goals.Select(g => new GoalDTO
            {
                GoalId = g.GoalId,
                EmployeeId = g.EmployeeId,
                GoalDescription = g.GoalDescription,
                TargetDate = g.TargetDate,
                IsCompleted = g.IsCompleted,
                EmployeeFirstName = g.Employee.FirstName
            }).ToList();
        }
    }
}
