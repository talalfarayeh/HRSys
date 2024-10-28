using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
    public class TaxRule
    {
        public int TaxRuleId { get; set; }  // Primary Key
        public decimal MinSalary { get; set; }  
        public decimal MaxSalary { get; set; }  
        public decimal TaxPercentage { get; set; }  
    }
}
