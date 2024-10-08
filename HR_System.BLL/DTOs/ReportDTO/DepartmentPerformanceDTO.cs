using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs.ReportDTO
{
    public class DepartmentPerformanceDTO
    {
        public string DepartmentName { get; set; }  
        public double AverageScore { get; set; }    
        public int TotalEmployees { get; set; }     
        public int CompletedReviews { get; set; }
    }
}
