using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs
{
    public class PerformanceReviewDTO
    {
        public int PerformanceReviewId { get; set; }
        public int EmployeeId { get; set; }
        public int ReviewerId { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Score { get; set; }
        public string? Comments { get; set; }

        public string EmployeeFirstName { get; set; } = string.Empty;

    }
}
