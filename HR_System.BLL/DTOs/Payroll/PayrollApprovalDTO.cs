using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs.Payroll
{

    public class PayrollApprovalDTO
    {
        public int PayrollId { get; set; }
        public bool IsApproved { get; set; } // Indicates whether the payment is approved or not
    }
}
