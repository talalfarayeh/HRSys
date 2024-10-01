using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
   public class PerformanceReview
    {
        public int ReviewId { get; set; }  
        public int EmployeeId { get; set; }   
        public int ReviewerId { get; set; }  
        public DateTime ReviewDate { get; set; }    
        public int Score { get; set; }   
        public string? Comments { get; set; }   

         
        public Employee? Employee { get; set; }
        public Employee? Reviewer { get; set; }

    }
}
