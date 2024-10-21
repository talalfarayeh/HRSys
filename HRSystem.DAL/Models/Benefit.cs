using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Models
{
    public class Benefit
    {
        public int BenefitId { get; set; }  
        public string BenefitName { get; set; }  
        public string Description { get; set; }  
        public bool IsMandatory { get; set; }

        public ICollection<EmployeeBenefit> EmployeeBenefits { get; set; } = new List<EmployeeBenefit>();

    }
}
