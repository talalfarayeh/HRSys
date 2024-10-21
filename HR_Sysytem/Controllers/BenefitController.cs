using HR_System.BLL.DTOs.Benefit;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitController : ControllerBase
    {
        private readonly IBenefitService _benefitService;

        public BenefitController(IBenefitService benefitService)
        {
            _benefitService = benefitService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBenefits()
        {
            var benefits = await _benefitService.GetAllBenefitsAsync();
            return Ok(benefits);
        }
        [HttpPost]
        public async Task<IActionResult> AddBenefit([FromBody] BenefitDTO benefitDto)
        {
            await _benefitService.AddBenefitAsync(benefitDto);
            return Ok("Benefit added successfully.");
        }
        [HttpPut("{benefitId}")]
        public async Task<IActionResult> UpdateBenefit(int benefitId, [FromBody] BenefitDTO benefitDto)
        {
            benefitDto.BenefitId = benefitId;
            await _benefitService.UpdateBenefitAsync(benefitDto);
            return Ok("Benefit updated successfully.");
        }
    }
}
