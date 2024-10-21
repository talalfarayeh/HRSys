using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
    public class EmployeeBenefit
    {
        public int EmployeeBenefitId { get; set; }   
        public int EmployeeId { get; set; } 
        public int BenefitId { get; set; }  
        public DateTime EnrollmentDate { get; set; }  
        public decimal CostToCompany { get; set; }  

        public Employee Employee { get; set; } 
        public Benefit Benefit { get; set; } 
    }
}
