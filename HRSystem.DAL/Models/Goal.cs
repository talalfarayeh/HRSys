using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
     public class Goal
    {
        public int GoalId { get; set; }  
        public int EmployeeId { get; set; }  
        public string? GoalDescription { get; set; }  
        public DateTime TargetDate { get; set; }  
        public bool IsCompleted { get; set; }  

        
        public Employee? Employee { get; set; }
    }
}
