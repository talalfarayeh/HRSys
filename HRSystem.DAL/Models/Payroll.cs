using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
    public class Payroll
    {
        public int PayrollId { get; set; } // Primary Key
        public int EmployeeId { get; set; } // Foreign Key
        public decimal BasicSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentStatus { get; set; } // "Pending" or "Completed"

        public Employee Employee { get; set; } // Navigation property to Employee
    }
}
