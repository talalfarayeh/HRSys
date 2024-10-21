using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs.Benefit
{
    public class EmployeeBenefitDTO
    {
        public int EmployeeBenefitId { get; set; }
        public int BenefitId { get; set; }
        public string BenefitName { get; set; }
        public decimal CostToCompany { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
