using HR_System.BLL.DTOs.Payroll;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplianceReportController : ControllerBase
    {
        private readonly IComplianceReportService _complianceReportService;

        public ComplianceReportController(IComplianceReportService complianceReportService)
        {
            _complianceReportService = complianceReportService;
        }

        [HttpGet("year-end-tax-report/{year}")]
        public async Task<IActionResult> GenerateYearEndTaxReport(int year)
        {
            var report = await _complianceReportService.GenerateYearEndTaxReportAsync(year);
            return Ok(report);
        }
         [HttpGet("DownloadYearEndTaxReport/{year}")]
        public async Task<IActionResult> DownloadYearEndTaxReport(int year)
        {
            var report = await _complianceReportService.GenerateYearEndTaxReportAsync(year);

            if (report == null || !report.Any())
            {
                return NotFound("No payroll data found for the specified year.");
            }

             var csv = GenerateCsv(report);
            var fileName = $"YearEndTaxReport_{year}.csv";

            return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", fileName);
        }

         private string GenerateCsv(List<PayrollReportDTO> report)
        {
            var csv = new StringBuilder();
            csv.AppendLine("EmployeeId,EmployeeName,BasicSalary,Bonus,Deductions,NetSalary,TaxesPaid");

            foreach (var record in report)
            {
                csv.AppendLine($"{record.EmployeeId},{record.EmployeeName},{record.BasicSalary},{record.Bonus},{record.Deductions},{record.NetSalary},{record.TaxesPaid}");
            }

            return csv.ToString();
        }
    }
}
