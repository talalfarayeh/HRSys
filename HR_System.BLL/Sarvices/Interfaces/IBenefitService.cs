using HR_System.BLL.DTOs.Benefit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices.Interfaces
{
    public interface IBenefitService
    {
        Task<List<BenefitDTO>> GetAllBenefitsAsync();
        Task<BenefitDTO> GetBenefitByIdAsync(int benefitId);
        Task AddBenefitAsync(BenefitDTO benefitDto);
        Task UpdateBenefitAsync(BenefitDTO benefitDto);
    }
}
