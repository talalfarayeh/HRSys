using HR_System.BLL.Sarvices;
using HR_System.BLL.Sarvices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;
        private readonly IPayrollPdfService _payrollPdfService;

        public PayrollController(IPayrollService payrollService, IPayrollPdfService payrollPdfService)
        {
            _payrollService = payrollService;
            _payrollPdfService = payrollPdfService;
        }
        [HttpPost("{employeeId}/generatePayroll")]
        public async Task<IActionResult> GeneratePayroll(int employeeId, int workingDays)
        {
            try
            {
                var payroll = await _payrollService.GeneratePayrollAsync(employeeId, workingDays);
                return Ok(payroll);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{payrollId}/approvePayroll")]
        public async Task<IActionResult> ApprovePayroll(int payrollId)
        {
            await _payrollService.ApprovePayrollAsync(payrollId);
            return Ok("Payroll approved successfully.");
        }
        [HttpGet("{employeeId}/aetPayrollHistory")]
        public async Task<IActionResult> GetPayrollHistory(int employeeId)
        {
            var payrollHistory = await _payrollService.GetPayrollHistoryAsync(employeeId);
            return Ok(payrollHistory);
        }
        [HttpGet("{payrollId}/download-pdf")]
        public async Task<IActionResult> DownloadPayrollPdf(int payrollId)
        {
            var payroll = await _payrollService.GetPayrollByIdAsync(payrollId);
            if (payroll == null) return NotFound();

            var pdfData = _payrollPdfService.GeneratePayrollPdf(payroll);
            return File(pdfData, "application/pdf", $"Payroll_{payrollId}.pdf");
        }
    }
}
