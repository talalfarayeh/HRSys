using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
    public class LeaveRequest
    {
        public int? LeaveRequestId { get; set; }    
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }     
        public string LeaveType { get; set; }     
        public string Status { get; set; }        
        public DateTime RequestDate { get; set; }  
        public DateTime? ApprovalDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
