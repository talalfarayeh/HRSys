using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs
{
    public class GoalDTO
    {
        public int GoalId { get; set; }
        public int EmployeeId { get; set; }
        public string GoalDescription { get; set; }
        public DateTime TargetDate { get; set; }
        public bool IsCompleted { get; set; }
        public string EmployeeFirstName { get; set; } = string.Empty;
    }
}
