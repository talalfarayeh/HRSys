using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
    public class SalaryComponent
    {
        public int SalaryComponentId { get; set; } // Primary Key
        public string ComponentName { get; set; } // e.g., Base Salary, Bonus, Deductions
        public decimal Amount { get; set; }
        public int EmployeeId { get; set; } // Foreign Key

        public Employee Employee { get; set; } // Navigation property
    }
}
