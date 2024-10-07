using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs.ReportDTO
{
    public class AverageLeaveTakenDTO
    {

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public double AverageLeaveTaken { get; set; }
    }
}
