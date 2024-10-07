using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs.ReportDTO
{
    public class EmployeeGoalCompletionDTO
    {
        public string EmployeeName { get; set; }
        public int GoalsCompleted { get; set; }
        public int TotalGoals { get; set; }
    }
}
