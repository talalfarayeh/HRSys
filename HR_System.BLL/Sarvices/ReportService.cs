﻿using HR_System.BLL.DTOs;
using HR_System.BLL.DTOs.ReportDTO;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.DAL.Repositories;
using HRSystem.DAL.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public async Task<List<EmployeeLeaveReportDTO>> GetAverageLeavePerEmployeeAsync()
        {
            var employees = await _reportRepository.GetEmployeesWithLeaveDataAsync();

            return employees.Select(e => new EmployeeLeaveReportDTO
            {
                EmployeeName = $"{e.FirstName} {e.LastName}",
                AverageLeaveTaken = e.LeaveRequests
                    .Where(lr => lr.Status == "Approved")
                    .Average(lr => EF.Functions.DateDiffDay(lr.StartDate, lr.EndDate))
            }).ToList();
        }
        public async Task<List<DepartmentPerformanceDTO>> GetPerformanceTrendsAsync()
        {
            var employees = await _reportRepository.GetEmployeesWithPerformanceDataAsync();

            return employees.GroupBy(e => e.EmployeeDepartments.FirstOrDefault()?.Department.DepartmentName)
                .Select(g => new DepartmentPerformanceDTO
                {
                    DepartmentName = g.Key,
                    AverageScore = g.Average(e => e.PerformanceReviews.Average(pr => pr.Score))
                }).ToList();
        }
        public async Task<List<EmployeeGoalCompletionDTO>> GetGoalCompletionRatesAsync()
        {
            var employees = await _reportRepository.GetEmployeesWithGoalsDataAsync();

            return employees.Select(e => new EmployeeGoalCompletionDTO
            {
                EmployeeName = $"{e.FirstName} {e.LastName}",
                GoalsCompleted = e.Goals.Count(g => g.IsCompleted),
                TotalGoals = e.Goals.Count()
            }).ToList();
        }
    }
}