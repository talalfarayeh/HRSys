using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs
{
    namespace HR_System.BLL.DTOs
    {
        public class PayrollDTO
        {
            public int PayrollId { get; set; }
            public int EmployeeId { get; set; }
            public string EmployeeFirstName { get; set; }
            public string EmployeeLastName { get; set; }
            public decimal BasicSalary { get; set; }
            public decimal Bonus { get; set; }
            public decimal Deductions { get; set; }
            public decimal NetSalary { get; set; }
            public DateTime PaymentDate { get; set; }
            public string PaymentStatus { get; set; }

            // Property to combine first and last name
            public string EmployeeFullName => $"{EmployeeFirstName} {EmployeeLastName}";
        }
    }
}
