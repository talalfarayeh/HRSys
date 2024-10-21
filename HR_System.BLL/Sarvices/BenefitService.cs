using HR_System.BLL.DTOs.Benefit;
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.DAL.Models;
using HRSystem.DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_System.BLL.Sarvices
{
     public class BenefitService: IBenefitService
    {
        private readonly IBenefitRepository _benefitRepository;

        public BenefitService(IBenefitRepository benefitRepository)
        {
            _benefitRepository = benefitRepository;
        }

       

        public async Task<List<BenefitDTO>> GetAllBenefitsAsync()
        {
            var benefits = await _benefitRepository.GetAllBenefitsAsync();
            return benefits.Select(b => new BenefitDTO
            {
                BenefitId = b.BenefitId,
                BenefitName = b.BenefitName,
                Description = b.Description,
                IsMandatory = b.IsMandatory
            }).ToList();
        }

        public async Task<BenefitDTO> GetBenefitByIdAsync(int benefitId)
        {
            var benefit = await _benefitRepository.GetBenefitByIdAsync(benefitId);
            if (benefit == null) return null;

            return new BenefitDTO
            {
                BenefitId = benefit.BenefitId,
                BenefitName = benefit.BenefitName,
                Description = benefit.Description,
                IsMandatory = benefit.IsMandatory
            };
        }
        public async Task AddBenefitAsync(BenefitDTO benefitDto)
        {
            var benefit = new Benefit
            {
                BenefitName = benefitDto.BenefitName,
                Description = benefitDto.Description,
                IsMandatory = benefitDto.IsMandatory
            };

            await _benefitRepository.AddBenefitAsync(benefit);
        }

        public async Task UpdateBenefitAsync(BenefitDTO benefitDto)
        {
            var benefit = await _benefitRepository.GetBenefitByIdAsync(benefitDto.BenefitId);
            if (benefit == null) throw new Exception("Benefit not found");

            benefit.BenefitName = benefitDto.BenefitName;
            benefit.Description = benefitDto.Description;
            benefit.IsMandatory = benefitDto.IsMandatory;

            await _benefitRepository.UpdateBenefitAsync(benefit);
        }
    }
}
