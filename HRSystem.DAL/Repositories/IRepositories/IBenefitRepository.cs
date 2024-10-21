using HRSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.DAL.Repositories.IRepositories
{
    public interface IBenefitRepository
    {
        Task<List<Benefit>> GetAllBenefitsAsync();
        Task<Benefit> GetBenefitByIdAsync(int benefitId);
        Task AddBenefitAsync(Benefit benefit);
        Task UpdateBenefitAsync(Benefit benefit);
    }
}
