using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs.Payroll
{
    public class SalaryComponentDTO
    {
        public int SalaryComponentId { get; set; }
        public string ComponentName { get; set; }
        public decimal Amount { get; set; }
        public int EmployeeId { get; set; }
    }
}
