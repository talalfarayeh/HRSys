using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.DTOs.Benefit
{
    public class BenefitDTO
    {
        public int BenefitId { get; set; }
        public string BenefitName { get; set; }
        public string Description { get; set; }
        public bool IsMandatory { get; set; }
    }
}
